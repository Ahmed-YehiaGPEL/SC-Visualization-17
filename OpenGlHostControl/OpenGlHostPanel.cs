using System;
using System.Collections;
using System.Windows.Forms;
using Tao.OpenGl;
using Visualization;
using ColorModePanelControl;
using ColorUtilityPackage;
using Visualization.MathUtil;

namespace OpenGlHostControl
{
    public partial class OpenGlHostPanel : Tao.Platform.Windows.SimpleOpenGlControl
    {
        #region Prop
        public Mesh LoadedMesh => mesh;
        public Hashtable MeshData => mesh?.VarToIndex;
        public ColouringFunction ColouringFunction => colouringFunction;
        public RenderMode RenderMode => renderMode;
        public double TranslationFactor { get; set; }
        public double ScaleFactor { get; set; }
        public Axis RotationAxis => rotationAxis;
        public bool HookRenderOnPaintEvent { get; set; }
        public bool RenderIsoSurfaces { get; set; }
        private static Point3 InitialPoint => new Point3(0, 0, -800.0);

        #endregion

        #region Events
        public delegate void OnRenderModeChangedDelegate(RenderMode renderMode);
        public delegate void OnSelectedDataChangedDelegate();

        public event OnRenderModeChangedDelegate OnRenderChanged;
        public event OnSelectedDataChangedDelegate OnSelectedDataChanged;
        #endregion

        private RenderMode renderMode;
        private Mesh mesh;
        private Point3 translation;
        private Matrix rotation;
        private Axis rotationAxis;
        private Point3 scale;
        private bool isInitialized;
        private ColouringFunction colouringFunction;
        private ColorModePanel colorModePanel;
        
        public OpenGlHostPanel()
        {
            InitializeComponent();
            this.InitializeContexts();
            Init();
        }

        public void Init()
        {
            renderMode = RenderMode.WireFrame;
            TranslationFactor = 1.0d;
            ScaleFactor = 1.0d;
            translation = Point3.Zero;
            scale = Point3.One;
            rotation = new Matrix();
            rotationAxis = Axis.X;
            SetInternalEvents();
        }

        public void LoadMesh(string path)
        {
            renderMode = RenderMode.Filled;

            ResetTransformationValues();
            mesh = new Mesh(path);
            mesh.CalculateMinMaxBounds();
            Translate(InitialPoint);
            InitViewPort();

            if (HookRenderOnPaintEvent)
            {
                HookRender();
            }

            this.Refresh();

            isInitialized = true;
        }

        public void Reset()
        {
            mesh = null;
            isInitialized = false;
        }

        public void ActivateDataIndex(string key)
        {
            AssertInitialized();
            mesh.SetDataIndex(key);
            OnSelectedDataChanged?.Invoke();
        }

        public void SetColouringFunction(ColouringFunction function)
        {
            if (isInitialized)
            {
                this.colouringFunction = function;

                colorModePanel.ColouringFunction = function;
                Render();
                Refresh();
            }
        }

        public void SetPanel(ColorModePanel panel)
        {
            this.colorModePanel = panel;
            HookColorPanelEvents();
        }

        public void SetRotationAxis(Axis axis)
        {
            rotationAxis = axis;
        }

        public void SetRenderMode(RenderMode renderMode)
        {
            this.renderMode = renderMode;
            OnRenderChanged?.Invoke(renderMode);
        }

        public void RenderMeshIsoSurfaces(int isoSurfacesCount)
        {
            mesh.CalculateAndRenderIsoSurfaces(isoSurfacesCount, mesh.DataIndex);
            this.Render();
            this.Refresh();
        }

        public void RenderMeshLineContours(int lineContoursCount)
        {
            mesh.CalculateAndRenderLineContours(lineContoursCount, mesh.DataIndex);
            this.Render();
            this.Refresh();
        }
       
        #region Transformations

        public void Rotate(Point3 value)
        {

            AssertInitialized();
            //return to origin
            mesh.Transformation.Translate(translation * -1);
            Matrix rot;
            switch (rotationAxis)
            {
                case Axis.X:
                    rot = Matrix.RotationX(3 * value.x);
                    break;
                case Axis.Y:
                    rot = Matrix.RotationY(3 * value.y);
                    break;
                case Axis.Z:
                    rot = Matrix.RotationZ(3 * value.z);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            rotation = rot;
            mesh.Transformation.Multiply(rot, Order.Prepend);
            mesh.Transformation.Translate(translation);
            //perform gl rotation
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glMultMatrixd(mesh.Transformation.Data);
            Gl.glPopMatrix();
        }

        public void Translate(Point3 value)
        {
            translation += value;
            mesh.Transformation.Translate(value);
        }

        public void Scale(Point3 value)
        {
            scale += value;
            mesh.Transformation.Scale(value);
        }

        public void ResetTransform()
        {
            mesh.RestoreTransformation();
            ResetTransformationValues();
            Translate(InitialPoint);
        }

        private void ResetTransformationValues()
        {
            translation.Set(0, 0, 0);
            scale.Set(0, 0, 0);
            rotation.SetZero();
        }
        #endregion

        #region Input Handling
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!isInitialized)
            {
                return;
            }
            Point3 translationAmount = Point3.Zero;
            switch (e.KeyData)
            {
                case Keys.Up:
                    translationAmount = Point3.Up * TranslationFactor;
                    break;
                case Keys.Down:
                    translationAmount = Point3.Down * TranslationFactor;
                    break;
                case Keys.Left:
                    translationAmount = Point3.Left * TranslationFactor;
                    break;
                case Keys.Right:
                    translationAmount = Point3.Right * TranslationFactor;
                    break;
                case Keys.PageUp:
                    translationAmount = Point3.Back * TranslationFactor;
                    break;
                case Keys.PageDown:
                    translationAmount = Point3.Forward * TranslationFactor;
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
            Translate(translationAmount);
            this.Refresh();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Keys key = (Keys)e.KeyChar;
            if (e.KeyChar == 'r' || e.KeyChar == 'R')
            {
                Rotate(Point3.One);
                Refresh();
                return;
            }

            Point3 scaleAmount = Point3.One;
            switch (e.KeyChar)
            {

                case 'x':
                case 'X': // +X
                    scaleAmount = Point3.One + (Point3.Right * ScaleFactor);
                    break;
                case 'c':
                case 'C':    // -X
                    scaleAmount = new Point3(ScaleFactor * 0.5, 1, 1);
                    break;

                case 'y':
                case 'Y':// +Y
                    scaleAmount = Point3.One + (Point3.Up * ScaleFactor);
                    break;
                case 'h':
                case 'H':// -Y
                    scaleAmount = new Point3(1,ScaleFactor * .5,1);
                    break;
                default:
                    base.OnKeyPress(e);
                    return;
            }
            Scale(scaleAmount);
            this.Refresh();
        }
        #endregion

        private void SetInternalEvents()
        {
            OnRenderChanged += (mode) => this.Refresh();
            OnSelectedDataChanged += this.Refresh;
        }

        private void AssertInitialized()
        {
            if (isInitialized == false)
            {
                throw new Exception("Panel not initialized, consider calling load first.");
            }
        }

        private void InitViewPort()
        {
            /*
             Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(0, 0, 0, 0);
            Gl.glViewport(0, 0, this.Width, this.Height);
            Glu.gluOrtho2D(-this.Width, this.Width, -this.Height, this.Height);
            Glu.gluPerspective(1, this.Width / (float)this.Height, 0, 200);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            */
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60.0, this.Width / (float)this.Height, 0.01, 200000);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LESS);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(0, 0, 0, 0);
            Gl.glViewport(0, 0, this.Width, this.Height);
        }

        private void Render()
        {
            if (!isInitialized)
            {
                return;
            }
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(0, 0, 0, 0);
            switch (renderMode)
            {
                case RenderMode.Filled:
                    mesh.RenderShape();
                    break;
                case RenderMode.WireFrame:
                    mesh.RenderWireFrame();
                    break;
            }
            mesh.RenderLineContours();
            mesh.RenderIsoSurfaces();
            Gl.glFlush();
        }

        private void HookColorPanelEvents()
        {
            if (colorModePanel != null)
            {
                colorModePanel.OnColorSetChanged += () =>
                {
                    this.Render();
                    this.Refresh();
                };
            }
        }

        private void HookRender()
        {
            this.Paint += (e, r) => this.Render();
        }
    }
}
