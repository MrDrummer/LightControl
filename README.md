# LightControl
Christmas tree light decorations controlled via a web app.
I have 6 strips of individually addressable LEDs from Adafruit. Connected in 2 strands of 3.
## Components
- Web app (Angular? Blazor?)
  - Hosted either on Firebase Hosting or Raspberry Pi
- C++ for the Arduino
  - Updated via Raspberry Pi
- Communication layer
  - If Web app hosted on pi, then serial
  - If web app hosted on Firebase Hosting/external, then via WebSocket or Pub/Sub
- Update layer
  - Cloud build?
  - Gets told to git pull via Pub/Sub?
  - Could be a button on the web app to force arduino to get updated?

Best case:
- Angular hosted on Pi
- Commands from site interface with Arduino via Serial
- Arduino gets updated by Pi, and its pattern can be updated on the fly.
- Can get updated without needing to SSH or directly connect to it via monitor.
