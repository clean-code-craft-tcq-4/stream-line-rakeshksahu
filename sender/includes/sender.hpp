#ifndef SENDER_HPP_
#define SENDER_HPP_

#include <iostream>
#include <memory>
#include "BMSParam.hpp"

using namespace std;

void printDataToConsole(const vector<float>& data)
{ 
    if (!data.empty())
    {
      int32_t index = 0;
      cout << setprecision(2);
      for (index = 0; index < data.size()-1; ++index)
      {
        cout << data[index] << ", ";
      }
      cout << data[index] <<endl;
    }
}

bool sendSensorDataToConsole(uint32_t numberOfReadings){
  bool isDataSentSuccessfully {false};
  shared_ptr<BMSParam> temp(new Temperature()); 
  shared_ptr<BMSParam> stateOfCharge(new SOC());
  shared_ptr<BMSParam> rateOfCharge(new ChargeRate());

  vector<float> temperatureValues = temp->generateValues(numberOfReadings);
  vector<float> SOCValues = stateOfCharge->generateValues(numberOfReadings);
  vector<float> rateValues = rateOfCharge->generateValues(numberOfReadings);
  
  if((temperatureValues.size() == numberOfReadings) && (SOCValues.size() == numberOfReadings) && 
  (rateValues.size() == numberOfReadings))
  {
    printDataToConsole(temperatureValues);
    printDataToConsole(SOCValues);
    printDataToConsole(rateValues);
    isDataSentSuccessfully = true;
  }
  return isDataSentSuccessfully;
}


#endif