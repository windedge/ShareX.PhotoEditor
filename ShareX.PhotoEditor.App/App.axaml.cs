#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2026 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ShareX.AvaloniaUI.Theming;
using ShareX.HelpersLib;
using ShareX.PhotoEditor.Integration;
using ShareX.PhotoEditor.UI;
using ShareX.PhotoEditor.UI.Commands;
using System;
using System.IO;

namespace ShareX.PhotoEditor.App
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            ThemeManager.Configure(new ApplicationThemeOptions());

            using (MemoryStream iconStream = new(ShareXResources.IconBytes, writable: false))
            {
                Resources["ShareX.WindowIcon"] = new WindowIcon(iconStream);
            }

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                string sharexFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ShareX");
                PhotoEditorServices services = new()
                {
                    SettingsFilePath = Path.Combine(sharexFolder, "PhotoEditor.App.json"),
                    DefaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    CopyImage = bitmap => ClipboardHelpers.CopyImage(bitmap)
                };

                PhotoEditorWindow window = new(services)
                {
                    Icon = Resources["ShareX.WindowIcon"] as WindowIcon
                };
                desktop.MainWindow = window;

                if (desktop.Args != null)
                {
                    foreach (string path in desktop.Args.Where(File.Exists)) EditorCommands.OpenFile(window, path);
                }
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
