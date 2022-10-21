
//#define CATCH_CONFIG_MAIN 
//#include "test/catch.hpp"
//#include <assert.h>

#include "sender/includes/sender.hpp"
using namespace std;


/*
//disabling test cases to print required content for receiver on console
TEST_CASE("test set 1 - check the output for invalid number of readings") {
  REQUIRE(sendSensorDataToConsole(0));
}

TEST_CASE("test set 2 - check the output for valid number of readings") {
  REQUIRE(sendSensorDataToConsole(10));
}
*/

int main ()
{
  sendSensorDataToConsole(10);
  return 0;
}