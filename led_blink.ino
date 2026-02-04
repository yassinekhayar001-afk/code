// Petit programme d'allumage LED pour Arduino Uno
// Utilise la LED intégrée (pin 13).

const int LED_PIN = 13;

void setup() {
  pinMode(LED_PIN, OUTPUT);
}

void loop() {
  digitalWrite(LED_PIN, HIGH); // allume la LED
  delay(1000);                 // attend 1 seconde
  digitalWrite(LED_PIN, LOW);  // éteint la LED
  delay(1000);                 // attend 1 seconde
}
