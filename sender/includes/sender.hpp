#ifndef SENDER_HPP_
#define SENDER_HPP_

#include <iostream>
#include <memory>
#include <sstream>
#include <iterator>
#include "BMSParam.hpp"

using namespace std;

/******************************************************************************************************************
 * @brief this method is used to convert generated data into printable string format
 *
 * @param : data : vector of readings
 *
 * @return  string in readable format
 *
 ******************************************************************************************************************/
string toString(const vector<float>& data)
{
  stringstream strValue;
  if (!data.empty())
  {
    //set precision to 2 decimal places
    strValue.precision(2);
    copy(data.begin(), data.end()-1, ostream_iterator<float>(strValue, ", "));
    strValue<<*(data.end()-1);
  }
  return strValue.str();
}

/******************************************************************************************************************
 * @brief this method is used to send different BMS sersor data to console
 *
 * @param : numberOfReadings : parameter holding number of readings to be sent
 *
 * @return  bool specifiying whether sending sensor data was succussful or not
 *
 ******************************************************************************************************************/
bool sendSensorDataToConsole(uint32_t numberOfReadings){
  bool isDataSentSuccessfully {false};

  //Create temperature BMS param
  shared_ptr<BMSParam> temp(new Temperature()); 
  //Create state of charge BMS param
  shared_ptr<BMSParam> stateOfCharge(new SOC());
  //Create charging rate BMS param
  shared_ptr<BMSParam> rateOfCharge(new ChargeRate());

  //generating the values
  vector<float> temperatureValues = temp->generateValues(numberOfReadings);
  vector<float> SOCValues = stateOfCharge->generateValues(numberOfReadings);
  vector<float> rateValues = rateOfCharge->generateValues(numberOfReadings);
  
  //validating of generated number are matching with number of required readings
  if(!temperatureValues.empty() &&
    (temperatureValues.size() == numberOfReadings) && (SOCValues.size() == numberOfReadings) && 
  (rateValues.size() == numberOfReadings))
  {
    //print to json format for receiver application
    cout << "Temperature readings: {" << toString(temperatureValues) << "}" << endl;
    cout << "SOC readings: {" << toString(SOCValues) << "}" << endl;
    cout << "Charge Rate readings: {" << toString(rateValues) << "}" << endl;
    isDataSentSuccessfully = true;
  }
  return isDataSentSuccessfully;
}


#endif