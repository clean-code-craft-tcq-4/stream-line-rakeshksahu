#ifndef SENDER_HPP_
#define SENDER_HPP_

#include <iostream>
#include <memory>
#include "BMSParam.hpp"

using namespace std;

string toString(const vector<float>& data)
{
  stringstream strValue;
  if (!data.empty())
  {
    strValue.precision(2);
    copy(data.begin(), data.end()-1, ostream_iterator<float>(strValue, ", "));
    strValue<<*(data.end()-1);
  }
  return strValue.str();
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
    cout << "Temperature readings: {" << toString(temperatureValues) << "}" << endl;
    cout << "SOC readings: {" << toString(SOCValues) << "}" << endl;
    cout << "Charge Rate readings: {" << toString(rateValues) << "}" << endl;
    isDataSentSuccessfully = true;
  }
  return isDataSentSuccessfully;
}


#endif