# MinMenu CZ

MinMenu je jednoduchá Windows aplikace (.NET 9, WinForms), která zobrazí kontextové menu s odkazy (zástupci) z vybraného adresáře. Menu se zobrazí na pozici kurzoru myši a umožňuje rychlé spouštění programů nebo otevírání souborů pomocí zástupců.

## Funkce

- Zobrazení všech zástupců (*.lnk) v zadaném adresáři a jeho podadresářích.
- Ikony zástupců se zobrazují vedle názvu položky.
- Po kliknutí na položku se spustí odpovídající program/soubor.
- Menu se automaticky zavře po výběru nebo ztrátě fokusu.
- Okno aplikace je neviditelné, zobrazuje se pouze menu.

## Instalace

1. Naklonujte repozitář: git clone https://github.com/vlasta81/MinMenu.git
2. Otevřete projekt ve Visual Studio 2022 (nebo novějším).
3. Sestavte projekt (`.NET 9`).

## Použití

Spusťte aplikaci s parametrem, který určuje cestu k adresáři se zástupci: MinMenu.exe "Cesta\k\adresáři"

Pokud nezadáte žádný parametr, použije se výchozí složka: %USERPROFILE%\Links

Menu se zobrazí na pozici kurzoru myši.

## Požadavky

- Windows 10/11
- .NET 9
- Visual Studio 2022+ (pro sestavení ze zdrojů)

## Licence

MIT

# MinMenu EN

MinMenu is a simple Windows application (.NET 9, WinForms) that displays a context menu with shortcuts from a selected directory. The menu appears at the mouse cursor position and allows quick launching of programs or opening files via shortcuts.

## Features

- Displays all shortcuts (*.lnk) in the specified directory and its subdirectories.
- Shortcut icons are shown next to each menu item.
- Clicking a menu item launches the corresponding program/file.
- The menu automatically closes after selection or when it loses focus.
- The application window is invisible; only the menu is shown.

## Installation

1. Clone the repository: git clone https://github.com/vlasta81/MinMenu.git
2. Open the project in Visual Studio 2022 (or newer).
3. Build the project (`.NET 9`).

## Usage

Run the application with a parameter specifying the path to the directory containing shortcuts: MinMenu.exe "Path\to\directory"

If no parameter is provided, the default folder is used: %USERPROFILE%\Links

The menu will appear at the mouse cursor position.

## Requirements

- Windows 10/11
- .NET 9
- Visual Studio 2022+ (for building from source)

## License

MIT
