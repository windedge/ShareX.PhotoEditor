# ShareX PhotoEditor Standalone

A fork of [ShareX](https://github.com/ShareX/ShareX) that builds the ShareX photo editor as a standalone Windows application. This is not an official ShareX release.

## Features

- Layer-based editing with selections, masks, adjustment layers, filters, layer styles and retouching brushes
- Open images from the start screen, File menu, drag and drop, clipboard or command line
- Save PNG, JPG, GIF, BMP, WebP, ICO and editable ShareX project files
- Settings are stored in `Documents\ShareX\PhotoEditor.App.json`

Host-dependent ShareX features are not available in this build: upload, ShareX post-capture tasks, pin to screen, print, region capture and fullscreen capture.

## Download

Windows x64 installers and checksums are published as prereleases on the [releases page](https://github.com/windedge/ShareX.PhotoEditor/releases). The installer bundles a self-contained executable, so no .NET runtime is required. ARM64 is not included yet.

## Build

Requirements: Windows x64 and the .NET 11 SDK.

```bash
# Debug build
dotnet build ShareX.PhotoEditor.App/ShareX.PhotoEditor.App.csproj -c Debug -p:Platform=x64

# Self-contained single-file executable
dotnet publish ShareX.PhotoEditor.App/ShareX.PhotoEditor.App.csproj -c Release -p:Platform=x64 -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

The executable is written to `ShareX.PhotoEditor.App/bin/Release/win-x64/publish/`.

## License

This build follows the ShareX GPL license. See [LICENSE.txt](LICENSE.txt). Source code is available at https://github.com/windedge/ShareX.PhotoEditor.

For the original ShareX project and its full documentation, see https://github.com/ShareX/ShareX.
