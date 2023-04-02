# Vehicle-Hire-Amount-Calculation-System
This is a small system which create using C# to calculate vehicle hire amounts and record them in a database for customer billing and management reporting that can use for a vehicle rental company.


$Following are the details of the system.

This system is created which can be use for emerging travel & tour companies in Sri Lanka. I created system with imagination that I develop it to company named Ayubo Drive. This owns a fleet of vehicles ranging from cars, SUVs to vans. The vehicles that it owns are hired or rented with or without a driver. The tariffs are based on the vehicle type. Some of the vehicle types that it operates are, small car, sedan car, SVUs, Jeep (WD), 7-seater van and Commuter van. New vehicle types are to be added in the future. Vehicle rent and hire options are as below.

1.	Rent (With or without driver) – For each type of vehicle rates are given per day, per week and per month. Rate for a driver also given per day. Depending on the rent period the total rent amount needs to be calculated. For example: if a vehicle is rented for 10 days with a driver, total amount to be calculated as follows:
                              
                              Total rent = weeklyRent x 1 + dailyRent x 3 + dailyDriverCost x 10
                              

2.	Hire (with driver only) – These are based on packages such as airport drop, airport pickup, 100km per day package, 200km per day package etc. Standard rates are defined for a package type of a vehicle typeif that is applicable for that type of vehicle.For each package maximum km limit and maximum number of hours arealso defined. Extra km rate is also defined which is applicable if they run beyond the allocated km limit for the tour. For day tours if they exceed max hour limit,a waiting charge is applicable for extra hours. Driver overnight rate and vehicle night park rate also defined which is applicable for each night when the vehicle is hired for 2 or more days.




$ Following are the functions expected by the system.

1: Rent calculation.
Return the total rent_value when vehicle_no, rented_date, return_date, with_driver parameters are sent in. with_driver parameter is set to true or false depending whether the vehicle is rented with or without driver.

2: Day tour - hire calculation.
Calculate total hire_value when vehicle_no, package_type, start_time, end_time, start_km_reading, end_km_reading parameters are sent in. Should return base_hire_charge, waiting_charge and extra_km_charge as output parameters.

3: Long tour - hire calculation.
Calculate total hire_value when vehicle_no, package_type, start_date, end_date, start_km_reading, end_km_reading parameters are sent in. Should return base_hire_charge, overnight_stay_charge and extra_km_charge as output parameters.

