#ifndef BMS_PARAM_HPP_
#define BMS_PARAM_HPP_

#include <iostream>
#include <vector>

#define EARLY_WARNING_PERCENTAGE 5 

using namespace std;

/******************************************************************************************************************
 *
 * @brief This interface is responsible for generating parameter values based on number of reading required
 *
 ******************************************************************************************************************/
class BMSParam
{
    public:
    BMSParam() = default;
    virtual ~BMSParam();
    /******************************************************************************************************************
	 * @brief this method is used to generate readings
	 *
	 * @param : numberOfReadings : parameter holding number of readings required
	 *
	 * @return  vector holding generated readings
	 *
	 ******************************************************************************************************************/
    virtual vector<float> generateValues(uint32_t numberOfReadings) = 0;
};

/******************************************************************************************************************
 *
 * @brief This class is responsible for generating temperature values based on number of reading required
 *
 ******************************************************************************************************************/
class Temperature : public BMSParam
{
    public:
    vector<float> generateValues(uint32_t numberOfReadings) override;
    
    private:
    
    /* @brief member specifying Minimum temperature value.*/
    const float MIN_TEMP {0};

    /* @brief member specifying Maximum temperature value.*/
    const float MAX_TEMP {45};
};

/******************************************************************************************************************
 *
 * @brief This class is responsible for generating state of charge values based on number of reading required
 *
 ******************************************************************************************************************/
class SOC : public BMSParam
{
    public:
    vector<float> generateValues(uint32_t numberOfReadings) override;

    private:

    /* @brief member specifying Minimum soc value.*/
    const float MIN_SOC {20};

    /* @brief member specifying Maximum soc value.*/
    const float MAX_SOC {80};
};

/******************************************************************************************************************
 *
 * @brief This class is responsible for generating charge rate values based on number of reading required
 *
 ******************************************************************************************************************/
class ChargeRate : public BMSParam
{
    public:
    vector<float> generateValues(uint32_t numberOfReadings) override;

    private:

    /* @brief member specifying Minimum charge rate value.*/
    const float MIN_CHARGE_RATE {0};

    /* @brief member specifying Maximum charge rate value.*/
    const float MAX_CHARGE_RATE {.8};
};

#endif