
#define CATCH_CONFIG_MAIN  // This tells Catch to provide a main() - only do this in one cpp file
#include "test/catch.hpp"
#include "sender/includes/sender.hpp"
#include <assert.h>
using namespace std;

TEST_CASE("test set 1 - check the output") {
  REQUIRE(sendSensorDataToConsole(10));
  REQUIRE(sendSensorDataToConsole(0));
}
