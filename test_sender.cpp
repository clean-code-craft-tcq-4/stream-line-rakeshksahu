/*
#define CATCH_CONFIG_MAIN 
#include "test/catch.hpp"
#include <assert.h>
*/

#include "sender/includes/sender.hpp"
using namespace std;



//disabling test cases to print required content for receiver on console
/*
TEST_CASE("test set 1 - check the output for invalid number of readings") {
  REQUIRE(sendSensorDataToConsole(0));
}

TEST_CASE("test set 2 - check the output for valid number of readings") {
  REQUIRE(sendSensorDataToConsole(10));
}

TEST_CASE("test set 3 - check the output for valid number of readings for temperature BMS")
{
  shared_ptr<BMSParam> temp(new Temperature()); 
  auto tempReadings = temp->generateValues(0);
  CHECK(tempReadings.size() == 0);
  tempReadings.clear();
  int numberofreadings = 15;
  tempReadings = temp->generateValues(numberofreadings);
  CHECK(tempReadings.size() == numberofreadings);
}

TEST_CASE("test set 4 - check the output for valid number of readings for SOC BMS")
{
  shared_ptr<BMSParam> soc(new SOC()); 
  auto socReadings = soc->generateValues(0);
  CHECK(socReadings.size() == 0);
  socReadings.clear();
  int numberofreadings = 15;
  socReadings = soc->generateValues(numberofreadings);
  CHECK(socReadings.size() == numberofreadings);
}

TEST_CASE("test set 5 - check the output for valid number of readings for Charge rate BMS")
{
  shared_ptr<BMSParam> crate(new ChargeRate()); 
  auto crReadings = crate->generateValues(0);
  CHECK(crReadings.size() == 0);
  crReadings.clear();
  int numberofreadings = 15;
  crReadings = crate->generateValues(numberofreadings);
  CHECK(crReadings.size() == numberofreadings);
}
*/

int main ()
{
  sendSensorDataToConsole(10);
  return 0;
}