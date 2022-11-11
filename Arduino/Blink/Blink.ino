#include <Adafruit_NeoPixel.h>

#define LED_PIN 6
#define LED_COUNT 24

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
//   NEO_RGBW    Pixels are wired for RGBW bitstream (NeoPixel RGBW products)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(LED_COUNT, LED_PIN, NEO_GRB + NEO_KHZ800);

// the setup function runs once when you press reset or power the board
void setup() {
  Serial.begin(9600);
  strip.begin();
  strip.setBrightness(64);
  strip.show(); // Initialize all pixels to 'off'
}

// the loop function runs over and over again forever
void loop() {
  strip.setPixelColor(0, 255, 0, 255);
  strip.show();
}
