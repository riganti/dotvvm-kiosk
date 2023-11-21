# Demos for the DotVVM conference kiosk

This repo contains 4 demos of a [DotVVM framework](https://github.com/riganti/dotvvm):

1. Basic principles of MVVM approach in DotVVM
2. Working with data using EF Core and using the `GridView` control
3. Using React components in DotVVM pages
4. Auto-generating forms and grids using `AutoUI`

## How to run

Projects 1, 2 and 4 can be run just by pressing F5 in Visual Studio, or by `dotnet run` in the project directory.

To run project 3, navigate in the project directory in the shell and run these commands:

```
# make sure you have Node.js installed
npm ci
npm run build
```

Then, you can run the project by pressing F5 or by running `dotnet run` in the project directory..
