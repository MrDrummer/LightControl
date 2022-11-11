#include <Adafruit_NeoPixel.h>

class Strip
{
public:
  uint8_t   effect;
  uint8_t   effects;
  uint16_t  effStep;
  unsigned long effStart;
  Adafruit_NeoPixel strip;
  Strip(uint16_t leds, uint8_t pin, uint8_t toteffects, uint16_t striptype) : strip(leds, pin, striptype) {
    effect = -1;
    effects = toteffects;
    Reset();
  }
  void Reset(){
    effStep = 0;
    effect = (effect + 1) % effects;
    effStart = millis();
  }
};

struct Loop
{
  uint8_t currentChild;
  uint8_t childs;
  bool timeBased;
  uint16_t cycles;
  uint16_t currentTime;
  Loop(uint8_t totchilds, bool timebased, uint16_t tottime) {currentTime=0;currentChild=0;childs=totchilds;timeBased=timebased;cycles=tottime;}
};

Strip strip_0(24, 6, 24, NEO_GBR + NEO_KHZ800);
Strip strip_1(12, 7, 12, NEO_GRB + NEO_KHZ800);
struct Loop strip0loop0(1, false, 1);
struct Loop strip1loop0(1, false, 1);

//[GLOBAL_VARIABLES]

void setup() {

  //Your setup here:

  strip_0.strip.begin();
  strip_1.strip.begin();
  strip_0.strip.setBrightness(64);
  strip_1.strip.setBrightness(64);
}

void loop() {

  //Your code here:

  strips_loop();
}

void strips_loop() {
  if(strip0_loop0() & 0x01)
    strip_0.strip.show();
  if(strip1_loop0() & 0x01)
    strip_1.strip.show();
}

uint8_t strip0_loop0() {
  uint8_t ret = 0x00;
  switch(strip0loop0.currentChild) {
    case 0: 
           ret = strip0_loop0_eff0();break;
  }
  if(ret & 0x02) {
    ret &= 0xfd;
    if(strip0loop0.currentChild + 1 >= strip0loop0.childs) {
      strip0loop0.currentChild = 0;
      if(++strip0loop0.currentTime >= strip0loop0.cycles) {strip0loop0.currentTime = 0; ret |= 0x02;}
    }
    else {
      strip0loop0.currentChild++;
    }
  };
  return ret;
}

uint8_t strip0_loop0_eff0() {
    // Strip ID: 0 - Effect: Rainbow - LEDS: 24
    // Steps: 75 - Delay: 50
    // Colors: 3 (255.0.0, 0.255.0, 0.0.255)
    // Options: rainbowlen=75, toLeft=false, 
  if(millis() - strip_0.effStart < 50 * (strip_0.effStep)) return 0x00;
  float factor1, factor2;
  uint16_t ind;
  for(uint16_t j=0;j<24;j++) {
    ind = 75 - (uint16_t)(strip_0.effStep - j * 1) % 75;
    switch((int)((ind % 75) / 25)) {
      case 0: factor1 = 1.0 - ((float)(ind % 75 - 0 * 25) / 25);
              factor2 = (float)((int)(ind - 0) % 75) / 25;
              strip_0.strip.setPixelColor(j, 255 * factor1 + 0 * factor2, 0 * factor1 + 255 * factor2, 0 * factor1 + 0 * factor2);
              break;
      case 1: factor1 = 1.0 - ((float)(ind % 75 - 1 * 25) / 25);
              factor2 = (float)((int)(ind - 25) % 75) / 25;
              strip_0.strip.setPixelColor(j, 0 * factor1 + 0 * factor2, 255 * factor1 + 0 * factor2, 0 * factor1 + 255 * factor2);
              break;
      case 2: factor1 = 1.0 - ((float)(ind % 75 - 2 * 25) / 25);
              factor2 = (float)((int)(ind - 50) % 75) / 25;
              strip_0.strip.setPixelColor(j, 0 * factor1 + 255 * factor2, 0 * factor1 + 0 * factor2, 255 * factor1 + 0 * factor2);
              break;
    }
  }
  if(strip_0.effStep >= 75) {strip_0.Reset(); return 0x03; }
  else strip_0.effStep++;
  return 0x01;
}

uint8_t strip1_loop0() {
  uint8_t ret = 0x00;
  switch(strip1loop0.currentChild) {
    case 0: 
           ret = strip1_loop0_eff0();break;
  }
  if(ret & 0x02) {
    ret &= 0xfd;
    if(strip1loop0.currentChild + 1 >= strip1loop0.childs) {
      strip1loop0.currentChild = 0;
      if(++strip1loop0.currentTime >= strip1loop0.cycles) {strip1loop0.currentTime = 0; ret |= 0x02;}
    }
    else {
      strip1loop0.currentChild++;
    }
  };
  return ret;
}

uint8_t strip1_loop0_eff0() {
    // Strip ID: 1 - Effect: Rainbow - LEDS: 12
    // Steps: 37 - Delay: 25
    // Colors: 3 (255.0.0, 0.255.0, 0.0.255)
    // Options: rainbowlen=37, toLeft=false, 
  if(millis() - strip_1.effStart < 25 * (strip_1.effStep)) return 0x00;
  float factor1, factor2;
  uint16_t ind;
  for(uint16_t j=0;j<12;j++) {
    ind = 37 - (uint16_t)(strip_1.effStep - j * 1) % 37;
    switch((int)((ind % 37) / 12.333333333333334)) {
      case 0: factor1 = 1.0 - ((float)(ind % 37 - 0 * 12.333333333333334) / 12.333333333333334);
              factor2 = (float)((int)(ind - 0) % 37) / 12.333333333333334;
              strip_1.strip.setPixelColor(j, 255 * factor1 + 0 * factor2, 0 * factor1 + 255 * factor2, 0 * factor1 + 0 * factor2);
              break;
      case 1: factor1 = 1.0 - ((float)(ind % 37 - 1 * 12.333333333333334) / 12.333333333333334);
              factor2 = (float)((int)(ind - 12.333333333333334) % 37) / 12.333333333333334;
              strip_1.strip.setPixelColor(j, 0 * factor1 + 0 * factor2, 255 * factor1 + 0 * factor2, 0 * factor1 + 255 * factor2);
              break;
      case 2: factor1 = 1.0 - ((float)(ind % 37 - 2 * 12.333333333333334) / 12.333333333333334);
              factor2 = (float)((int)(ind - 24.666666666666668) % 37) / 12.333333333333334;
              strip_1.strip.setPixelColor(j, 0 * factor1 + 255 * factor2, 0 * factor1 + 0 * factor2, 255 * factor1 + 0 * factor2);
              break;
    }
  }
  if(strip_1.effStep >= 37) {strip_1.Reset(); return 0x03; }
  else strip_1.effStep++;
  return 0x01;
}
