/**
 * Your ParkingSystem object will be instantiated and called as such:
 * var obj = new ParkingSystem(big, medium, small)
 * var param_1 = obj.addCar(carType)
 */

class ParkingSystem {
  big: number;
  medium: number;
  small: number;

  constructor(big: number, medium: number, small: number) {
    this.big = big || 0;
    this.medium = medium || 0;
    this.small = small || 0;
  }

  addCar(carType: number) {
    const dict: Record<string, number> = {
      "1": this.big,
      "2": this.medium,
      "3": this.small,
    };
    const space = dict[String(carType)];

    if (space > 0) {
      if (carType === 1) this.big--;
      if (carType === 2) this.medium--;
      if (carType === 3) this.small--;
      return true;
    }

    return false;
  }
}

const parkingSystem1 = new ParkingSystem(1, 1, 0);
console.log(parkingSystem1.addCar(1), "correct:", true);
console.log(parkingSystem1.addCar(2), "correct:", true);
console.log(parkingSystem1.addCar(3), "correct:", false);
console.log(parkingSystem1.addCar(1), "correct:", false);
