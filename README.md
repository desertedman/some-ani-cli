# dotnet-ani-cli

Watch anime straight from the terminal!

Built off of <https://github.com/Slimyslushy/anikoto-cli>

Scrapes the MyAnimeList API for search results, and feeds it into the Anikoto/
Megaplay API. Uses Jikan API for episode information.

## Requirements

- mpv
- vlc support planned
- .NET runtime (only version 10 tested)
- Linux; Windows support planned

If so inclined to run on Windows or use VLC, you can simply change
the "PlayEpisode" function and modify the launch options accordingly.

## Running

```bash
git clone https://github.com/desertedman/dotnet-ani-cli.git
cd dotnet-ani-cli
dotnet run
```

## Launch Options

- `--c` - Choose subtitle track. If not specified, uses the default subtitle
track (usually English)

## Disclaimer

Large amounts of assistance provided by AI. Used to:

- Understand original script
- Vibecode

## Libraries

- [HTML Agility Pack](https://html-agility-pack.net/)
