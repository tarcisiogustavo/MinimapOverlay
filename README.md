# MinimapOverlay

MinimapOverlay is a Windows application designed to automate the creation of perimeter zones for FiveM. It allows users to define zones using coordinates, visualize them and export it as a png file.


## Features

- **Coordinate Input:** Enter coordinates in the format `(x, y)` to define zones.
- **Image Generation:** Create images of zones with fill and borders.
- **Transparency and Color Adjustments:** Customize the polygon's opacity and color.
- **Scale Calculations:** Dynamically calculate scales and the geometric center of the zone.
- **Export:** Save generated images in PNG format.

## Screenshot

![MinimapOverlay](https://github.com/user-attachments/assets/24345d9d-af4f-4069-ad2f-a660a36b9072)

## Requirements

- .NET Framework 4.7.2 or later
- [SkiaSharp](https://github.com/mono/SkiaSharp)

## How to Use

1. **Download the Compiled Version:** Get the latest version from the [Releases](https://github.com/tarcisiogustavo/MinimapOverlay/releases/tag/v1.0.0) section.
2. **Run the Executable:** Open the `MinimapOverlay.exe` file.
3. **Input Coordinates:** Add coordinates in the text field in the format `(x, y)`.
4. **View the Polygon:** The generated polygon will be displayed in the main window.
5. **Customize:**
   - Adjust transparency using the slider.
   - Choose the polygon color using the color picker.
6. **Export:** Click **Export** to save the generated image as a PNG file.

## Coordinate Input Format

Coordinates must be entered in the following format:
```
 vector2(152.68, -1001.39),
 vector2(141.80, -997.53),
 vector2(131.95, -994.35),

or

 (152.68, -1001.39),
 (141.80, -997.53),
 (131.95, -994.35),

```

## Development

### Technologies Used

- **Language:** C#
- **UI Framework:** Windows Forms
- **Graphics Engine:** SkiaSharp

### Setting Up the Development Environment

1. Clone the repository
2. Open the project in Visual Studio.
3. Restore NuGet packages.
4. Build and run the project.


### Contact
Discord: arron_0n
