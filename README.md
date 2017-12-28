# SC-Visualization-17

Scientific Computing Visualization'17 Course Package Implementation

This pacakge has been created as the work of Scientifc Computing - Visualization 2017 course implementation.

## Installation

All package dlls are included within the project setup **`PlugNPlayTM`**.

It uses the following external frameworks:

1. Tao OpenGl Framework for C#


## Features:

1. Loading Data model based on special format file. _Found in "./Models"
2. Rendring Data model in two different rendering modes.
3. User defined Color Keys for data.
4. Ability to manipulate data model transfomation in a 3D Space.
5. Contouring for 2D and 3D Data Models (Line Contouring, IsoSurfaces)

## Usage:

1. Choose a model file from the provided models found in folder: "./Models"
2. Click on `Load Model` to load and render the model directly into the viewing port.
3. Manipulate the model transformations if needed, refer to the `Legend` section in the UI for shortcuts.
4. Navigate the `Rendering` tab to manipulate the color map and the colouring function provided.
5. Also  in the `Rendering` tab you can change which data type to render in the model.
6. If the model is a 2D Data model then you can use the contouring tab to generate line contours for each data type.
7. If the model is a 3D Data model then you can use the contouring tab to generate IsoSurfaces for each data type.

## Provided Models:

**3D Models:**

* cavity54.dat

**2D Models:**

* 2 Triangles.dat
* big.dat **_Recommended for line contouring_**
* crank_noTitle.dat
* new.dat
* Quad.dat

## Closing

Feel free to contribute either with issues reporting or forks and pull requests.

This package is just an educational experimenting package with visualization using an old framework `TaoOpenGl`.

Estimated average working hours is around **48 hours** of coding. 
