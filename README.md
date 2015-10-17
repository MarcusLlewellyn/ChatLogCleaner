## Description

This is a very simple chat log sanitizer for Linden Lab based clients, primarily with OpenSimulator based virtual worlds.

The logs produced by these clients, although human readable, are a little too verbose for some situations. For example, posting a chat log on a wiki, or showing in-world chat in a video recording.

The main impetus behind this project was the latter use case. I needed a nice way to present in-world chat on a video stream. The chat had to be reasonably readable at a 480p resolution, and formatted in a way that made it easy for most people to parse. Also, nobody needs to know when your friends have logged on or off, you've been offered inventory, etc.

Currently, the cleaned results are logged to a file. Some livestream broadcast software will allow you to pull directly from this file, and format it as you like in your video. This program also can display the cleaned chat in a window of its own, allowing broadcast software to capture that window.

## Disclaimer

This is a project intended to fulfill a personal need. It is not gauranteed to be particularly polished, free from errors, or crashproof.