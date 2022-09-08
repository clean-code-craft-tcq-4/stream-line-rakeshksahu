#ifndef BMS_PARAM_HPP_
#define BMS_PARAM_HPP_

#include <iostream>
#include <vector>

#define EARLY_WARNING_PERCENTAGE 5 

using namespace std;

class BMSParam
{
    public:
    BMSParam() = default;
    virtual ~BMSParam();
    virtual vector<float> generateValues(uint32_t numberOfReadings) = 0;
};

class Temperature : public BMSParam
{
    public:
    vector<float> generateValues(uint32_t numberOfReadings) override;
    private:
    const float MIN_TEMP {0};
    const float MAX_TEMP {45};
};

class SOC : public BMSParam
{
    public:
    vector<float> generateValues(uint32_t numberOfReadings) override;
    private:
    const float MIN_SOC {20};
    const float MAX_SOC {80};
};

class ChargeRate : public BMSParam
{
    public:
    vector<float> generateValues(uint32_t numberOfReadings) override;
    private:
    const float MIN_CHARGE_RATE {0};
    const float MAX_CHARGE_RATE {.8};
};

#endif