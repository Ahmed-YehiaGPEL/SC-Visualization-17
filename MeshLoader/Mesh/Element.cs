using System;

namespace Visualization
{
    public class Element
    {
        public uint[] VertInOrder;
        private readonly uint[] faces;
        
        public Element(ElementType elementType)
        {
            switch (elementType)
            {
                case ElementType.FEBrick:
                case ElementType.IJKBrick:
                    faces = new uint[6];
                    break;
                case ElementType.Tetrahedron:
                    faces = new uint[4];
                    break;
                case ElementType.FEQuad:
                case ElementType.IJKQuad:
                case ElementType.Triangle:
                    faces = new uint[1];
                    break;
                case ElementType.Line:
                    throw new Exception("Logical Error");
            }
        }

        public Element(uint faceCount)
        {
            faces = new uint[faceCount];
        }
     
        public void SetQuad(uint f)
        {
            faces[0] = f;
        }

        public void SetTriangle(uint f)
        {
            faces[0] = f;
        }

        public void SetBrick(uint[] f)
        {
            f.CopyTo(faces, 0);
        }

        public void SetTetrahedron(uint[] f)
        {
            f.CopyTo(faces, 0);
        }

        public void SetBrickFrontFace(uint f)
        {
            faces[0] = f;
        }

        public void SetBrickRightFace(uint f)
        {
            faces[1] = f;
        }

        public void SetBrickBackFace(uint f)
        {
            faces[2] = f;
        }
        public void SetBrickLeftFace(uint f)
        {
            faces[3] = f;
        }

        public void SetBrickTopFace(uint f)
        {
            faces[4] = f;
        }

        public uint GetBrickTopFace()
        {
            return faces[4];
        }

        public void SetBrickBottomFace(uint f)
        {
            faces[5] = f;
        }

        public uint GetBrickBottomFace()
        {
            return faces[5];
        }

        public void SetTetrahedronFrontFace(uint f)
        {
            faces[0] = f;
        }

        public void SetTetrahedronRightFace(uint f)
        {
            faces[1] = f;
        }

        public void SetTetrahedronLeftFace(uint f)
        {
            faces[2] = f;
        }

        public void SetTetrahedronBaseFace(uint f)
        {
            faces[3] = f;
        }

        public void glTell(Zone owner, double min, double max, int index)
        {
            foreach (uint face in faces)
                owner.Faces[face].glTell(owner,min,max,index);
        }
    }
}