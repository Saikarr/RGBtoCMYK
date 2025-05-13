# CMYK Color Separator with Bezier Curve Control
## Overview
This Windows Forms (WinForms) application allows you to load an RGB image and separate it into CMYK color channels (Cyan, Magenta, Yellow, Black).
The separation process is controlled using customizable Bezier curves, which determine how much of each color component is extracted.

You can:\
✅ Load and save RGB images (JPEG, PNG, BMP)\
✅ Generate 4 separate CMYK images\
✅ Adjust the color generation using Bezier curves\
✅ Save and load curve presets for future use\
✅ Choose from 4 predefined curve options:
- No Back
- Full Back
- UCR
- GCR

## Features
1. Image Loading & Saving
- Open any RGB image (JPEG, PNG, BMP)
- Save the separated CMYK images individually
2. Bezier Curve Control
- Interactive curve editor (drag control points to adjust the black generation)
- 4 Preset Modes:
  - No Back – Removes most black, relying on CMY
  - Full Back – Maximizes black for deep shadows
  - UCR (Under Color Removal) – Removes color where black dominates, optimized for printing
  - GCR (Gray Component Replacement) – Replaces neutral tones with black (balanced black generation)
3. Curve Management
- Save your custom curves for later use
- Load previously saved curves
