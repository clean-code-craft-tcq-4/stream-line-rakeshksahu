#include "includes/BMSParam.hpp"

BMSParam::~BMSParam() = default;

vector<float> Temperature::generateValues(uint32_t numberOfReadings)
{
  vector<float> temperatureValueList;
  while (numberOfReadings--)
  {
    temperatureValueList.emplace_back(MIN_TEMP + static_cast <float> (rand()) /( static_cast <float> (RAND_MAX/(MAX_TEMP-MIN_TEMP))));
  }
  return temperatureValueList;

}


vector<float> SOC::generateValues(uint32_t numberOfReadings)
{
  vector<float> SOCValueList;
  while (numberOfReadings--)
  {
    SOCValueList.emplace_back(MIN_SOC + static_cast <float> (rand()) /( static_cast <float> (RAND_MAX/(MAX_SOC-MIN_SOC))));
  }
  return SOCValueList;

}

vector<float> ChargeRate::generateValues(uint32_t numberOfReadings)
{
  vector<float> rateValueList;
  while (numberOfReadings--)
  {
    rateValueList.emplace_back(MIN_CHARGE_RATE + static_cast <float> (rand()) /( static_cast <float> (RAND_MAX/(MAX_CHARGE_RATE-MIN_CHARGE_RATE))));
  }
  return rateValueList;
}