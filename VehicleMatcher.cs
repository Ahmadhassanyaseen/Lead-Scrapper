using System.Collections.Generic;

namespace Scraper
{
    public class VehicleMatcher
    {
        public Dictionary<string, int> Vehicles = new Dictionary<string, int>()
        {
            { "Multiple Vehicles", 0 },
            { "Bentley", 1 },
            { "Horse & Carriage", 2 },
            { "PT Cruiser Stretch", 3 },
            { "3 Passenger Luxury Sedan", 4 },
            { "BMW Sedan", 5 },
            { "Excalibur", 6 },
            { "Cadillac Sedan", 7 },
            { "Lincoln MKS Sedan", 8 },
            { "Toyota Avalon", 9 },
            { "Tesla Model S", 10 },
            { "Lincoln MKT Town Car", 11 },
            { "Lincoln Town Car", 12 },
            { "Hummer H3 Alpha", 13 },
            { "Cadillac STS", 14 },
            { "Chrysler 300", 15 },
            { "1957 Chevy Stretch", 16 },
            { "Chevy Suburban", 17 },
            { "Rolls Royce Classic", 18 },
            { "Lexus SUV", 19 },
            { "Lincoln Navigator", 20 },
            { "Cadillac Deville", 21 },
            { "Bentley Sedan", 22 },
            { "Luxury Sedan (Share Ride)", 23 },
            { "1956 White Cadillac", 24 },
            { "Jaguar Sedan", 25 },
            { "xXx_BMW Sedan_xXx", 26 },
            { "Other Exotic/Luxury Vehicle", 27 },
            { "Chevy Tahoe", 28 },
            { "Lexus Sedan", 29 },
            { "Other Classic Vehicles", 30 },
            { "Rolls Royce Sedan", 31 },
            { "Mercedes Sedan", 32 },
            { "Ford Expedition", 33 },
            { "GMC Yukon XL SUV", 34 },
            { "Rolls Royce Limousine", 35 },
            { "cCc_Lincoln Navigator", 36 },
            { "Cadillac DeVille Stretch ( 6 pass.)", 37 },
            { "Executive Van 6 Passenger", 38 },
            { "Van - 6 Passenger", 39 },
            { "Harley Davidson Limo", 40 },
            { "Super Stretch SUV Limo", 41 },
            { "Hummer SUV", 42 },
            { "Van - 6 Pass. Airport Shuttle (Share Ride)", 43 },
            { "Cadillac Escalade", 44 },
            { "Excalibur Stretch", 45 },
            { "Land Rover Stretch", 46 },
            { "Chevy Yukon Stretch", 47 },
            { "PT Cruiser (6 Passenger)", 48 },
            { "Mercedes Stretch", 49 },
            { "xXx_Excalibur", 50 },
            { "Limousine (6 Passenger)", 51 },
            { "Luxury Coach", 52 },
            { "SUV Sedan", 53 },
            { "Chevy Suburban Stretch", 54 },
            { "Jaguar Stretch", 55 },
            { "Corvette Limo", 56 },
            { "Tesla Model X", 57 },
            { "Chevy Suburban SUV", 58 },
            { "Ford Excursion", 59 },
            { "Van - 7 Passenger", 60 },
            { "Van - 7 Pass. Airport Shuttle (Share Ride)", 61 },
            { "7 Passenger Limousine", 62 },
            { "xXx_Ford Expedition", 63 },
            { "GMC - Denali", 64 },
            { "xXx_Lincoln Town Car", 65 },
            { "Chrysler 300 Stretch 8 Passenger", 66 },
            { "Beetle Limo", 67 },
            { "Hot Tub Limo", 68 },
            { "BMW Limo", 69 },
            { "Lexus Stretch", 70 },
            { "8 Passenger Limousine", 71 },
            { "Ford Excursion Stretch", 72 },
            { "Lincoln Navigator Stretch 1-8 Passenger", 73 },
            { "Ford Expedition Stretch", 74 },
            { "GMC Savanna", 75 },
            { "9 Passenger Limousine", 76 },
            { "Mercedes Limo Van", 77 },
            { "Chrysler 300 Stretch 10 Passenger", 78 },
            { "Cadillac DeVille Stretch (10 pass.)", 79 },
            { "Van - 10 Pass. Airport Shuttle (Share Ride)", 80 },
            { "Bentley Stretch Limousine", 81 },
            { "xXx_Rolls Royce Limousine", 82 },
            { "Ford Excursion Stretch 10 Passenger", 83 },
            { "Dodge Charger Limousine", 84 },
            { "000_Lincoln Town Car", 85 },
            { "Hummer H3 Limousine", 86 },
            { "10 Passenger Limousine", 87 },
            { "Pickup Limo Stretch", 88 },
            { "Limo Van", 89 },
            { "Executive Van 10 Passenger", 90 },
            { "Van - 10 Passenger", 91 },
            { "Lincoln Stretch Limo 10 Passenger", 92 },
            { "12 Passenger Limousine", 93 },
            { "Mercedes Benz Sprinter", 94 },
            { "Chrysler Aspen Limousine", 95 },
            { "Cadillac Escalade Limousine", 96 },
            { "xXx_Limobus_xXx", 97 },
            { "Ford Excursion Stretch 14 Passenger", 98 },
            { "Rolls Royce Super Stretch", 99 },
            { "Van - 14 Pass. Airport Shuttle (Share Ride)", 100 },
            { "Lincoln Navigator Stretch 9-14 Passenger", 101 },
            { "14 Passenger Limousine", 102 },
            { "Van - 14 Passenger", 103 },
            { "Party Bus", 104 },
            { "Ford Expedition EL", 105 },
            { "Van - 15 Passenger", 106 },
            { "Van - 15 Pass. Airport Shuttle (Share Ride)", 107 },
            { "p2p_Chrysler Aspen Limousine", 108 },
            { "Lincoln Navigator Stretch 16 Passenger", 109 },
            { "Hummer Stretch", 110 },
            { "zZz_Limobus", 111 },
            { "Ford Excursion Super Stretch 17 Passenger", 112 },
            { "Cadillac Escalade Stretch 18 Passenger", 113 },
            { "Nissan Infinity QX56", 114 },
            { "Hummer H2 Limousine", 115 },
            { "18 Passenger Limo Bus", 116 },
            { "20 Passenger Limousine", 117 },
            { "Minibus", 118 },
            { "Ford Excursion Super Stretch 20 Passenger", 119 },
            { "Cadillac Escalade Stretch 20 Passenger", 120 },
            { "H2 Hummer Stretch", 121 },
            { "Lincoln Navigator Stretch 20 Passenger", 122 },
            { "Jeep Commander Stretch", 123 },
            { "Mercedes GL550 SUV", 124 },
            { "Infiniti QX56 Super Stretch", 125 },
            { "x2x_Party Bus", 126 },
            { "gGg_Limobus", 127 },
            { "0xa0_Hummer H2 Limousine", 128 },
            { "Top Kick Limousine 20 Passenger", 129 },
            { "Luxury Mini Coach 21 Passenger", 130 },
            { "x0x_Hummer H2 Limousine", 131 },
            { "Ford Excursion Super Stretch 22 Passenger", 132 },
            { "pPp_Limobus", 133 },
            { "Cadillac Escalade Stretch 22 Passenger", 134 },
            { "20-22 Passenger Limo Bus", 135 },
            { "Minibus 20-24 Passenger (Share Ride)", 136 },
            { "Lincoln Navigator Stretch 15-24 Passenger", 137 },
            { "Top Kick Limousine 25 Passenger", 138 },
            { "25 Passenger Limousine", 139 },
            { "Motorcoach 11-26 Passenger", 140 },
            { "Motorcoach 26 Passenger", 141 },
            { "is3_Mercedes GL550 SUV", 142 },
            { "Cadillac Escalade Stretch 28 Passenger", 143 },
            { "Luxury Mini Coach 28 Passenger", 144 },
            { "Mini Bus", 145 },
            { "Top Kick Limousine 30 Passenger", 146 },
            { "Charter Bus", 147 },
            { "Coach (Bus)", 148 },
            { "Trolley", 149 },
            { "xpx_Party Bus", 150 },
            { "Minibus 32 Passenger (Share Ride)", 151 },
            { "Ford Excursion Bus", 152 },
            { "Luxury Mini Coach 35 Passenger", 153 },
            { "Minibus 36 Passenger (Share Ride)", 154 },
            { "Motorcoach 36 Passenger", 155 },
            { "Mega Party Bus", 156 },
            { "Luxury Mini Coach 41 Passenger", 157 },
            { "42 Passenger Limousine", 158 },
            { "GMC 5500 Super Stretch Limo", 159 },
            { "Limo Bus", 160 },
            { "Motorcoach 46 Passenger", 161 },
            { "Motorcoach 47 Passenger", 162 },
            { "Motorcoach 50 Passenger", 163 },
            { "Motorcoach 53 Passenger", 164 },
            { "Motorcoach 56 Passenger", 165 },
            { "Motorcoach 57 Passenger", 166 },
            { "Large Passengers Multiple Vehicles", 167 }
        };

        public Dictionary<int, string> Types = new Dictionary<int, string>()
        {
            { 0, "x-x-x-x-x-x-x-x-x-x-x-x-x-x-x" },
            { 1, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 2, "o-o-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 3, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 4, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 5, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 6, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 7, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 8, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 9, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 10, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 11, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 12, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 13, "o-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 14, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 15, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 16, "o-o-x-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 17, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 18, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 19, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 20, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 21, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 22, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 23, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 24, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 25, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 26, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 27, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 28, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 29, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 30, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 31, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 32, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 33, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 34, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 35, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 36, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 37, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 38, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 39, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 40, "o-o-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 41, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 42, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 43, "o-o-o-o-o-x-o-x-o-o-o-o-o-o-o" },
            { 44, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 45, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 46, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 47, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 48, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 49, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 50, "o-o-o-o-o-o-o-o-o-o-o-o-o-x-o" },
            { 51, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 52, "o-o-o-o-o-o-x-o-x-x-o-o-o-o-o" },
            { 53, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 54, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 55, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 56, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 57, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 58, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 59, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 60, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 61, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 62, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 63, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 64, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 65, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 66, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 67, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 68, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 69, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 70, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 71, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 74, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 75, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 76, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 77, "o-o-x-x-o-x-o-x-o-x-o-o-o-o-o" },
            { 78, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 79, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 80, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 81, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 82, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 83, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 84, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 85, "x-x-o-o-o-o-o-o-o-o-o-o-o-o-o" },
            { 86, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 87, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 88, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 89, "o-o-x-x-x-x-o-x-o-x-o-o-o-o-o" },
            { 90, "o-o-o-o-x-x-o-x-o-x-o-o-o-o-o" },
            { 91, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 92, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 93, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 94, "o-o-o-o-x-x-o-x-o-x-o-o-o-o-o" },
            { 95, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 96, "o-o-o-o-x-o-o-o-x-x-o-o-o-o-o" },
            { 97, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 98, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 99, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 100, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 101, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 102, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 103, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 104, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 105, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 106, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 107, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 108, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 109, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 110, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 111, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 112, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 113, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 114, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 115, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 116, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 117, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 118, "o-o-o-o-o-x-o-x-o-x-o-o-o-o-o" },
            { 119, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 120, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 121, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 122, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 123, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 124, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 125, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 126, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 127, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 128, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 129, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 130, "o-o-o-o-o-o-x-x-x-x-o-o-o-o-o" },
            { 131, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 132, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 133, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 134, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 135, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 136, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 137, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 138, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 139, "o-o-x-x-x-o-o-o-o-o-o-o-o-o-o" },
            { 140, "o-o-o-o-o-x-x-x-o-o-o-o-o-o-o" },
            { 141, "o-o-o-o-o-o-x-x-o-o-o-o-o-o-o" },
            { 142, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 143, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 144, "o-o-o-o-o-o-x-x-x-x-o-o-o-o-o" },
            { 145, "o-o-o-o-o-o-o-x-o-o-o-o-o-o-o" },
            { 146, "o-o-x-x-o-o-o-o-o-o-o-o-o-o-o" },
            { 147, "o-o-o-o-o-o-x-x-o-x-o-o-o-o-o" },
            { 148, "o-o-o-o-o-o-x-x-o-x-o-o-o-o-o" },
            { 149, "o-o-o-o-o-o-o-o-o-o-o-x-o-o-o" },
            { 150, "o-o-o-o-x-o-o-o-o-o-o-o-o-o-o" },
            { 151, "o-o-o-o-o-o-x-x-o-x-o-o-o-o-o" },
            { 152, "o-o-x-x-x-o-o-o-o-o-o-o-o-o-o" },
            { 153, "o-o-o-o-o-o-x-x-x-x-o-o-o-o-o" },
            { 154, "o-o-o-o-o-o-x-x-o-x-o-o-o-o-o" },
            { 155, "o-o-o-o-o-o-x-x-o-x-o-o-o-o-o" },
            { 156, "o-o-o-o-x-o-o-o-x-x-o-o-o-o-o" },
            { 157, "o-o-o-o-o-o-x-x-x-x-o-o-o-o-o" },
            { 158, "o-o-o-o-x-o-o-o-x-x-o-o-o-o-o" },
            { 159, "o-o-x-x-x-o-o-o-o-o-o-o-o-o-o" },
            { 160, "o-o-o-o-x-o-x-x-o-x-o-o-o-o-o" },
            { 161, "o-o-o-o-o-o-x-o-x-x-o-o-o-o-o" },
            { 162, "o-o-o-o-o-o-x-o-x-x-o-o-o-o-o" },
            { 163, "o-o-o-o-o-o-x-o-x-x-o-o-o-o-o" },
            { 164, "o-o-o-o-o-o-x-o-x-x-o-o-o-o-o" },
            { 165, "o-o-o-o-o-o-x-o-x-x-o-o-o-o-o" },
            { 166, "o-o-o-o-o-o-x-o-x-x-o-o-o-o-o" },
            { 167, "o-o-o-o-o-o-x-x-x-x-x-o-o-o-o" }
        };

        public Dictionary<int, int> Pricing = new Dictionary<int, int>()
        {
            { 0, 100 },
            { 1, 245 },
            { 2, 245 },
            { 3, 125 },
            { 4, 75 },
            { 5, 75 },
            { 6, 245 },
            { 7, 75 },
            { 8, 75 },
            { 9, 75 },
            { 10, 75 },
            { 11, 75 },
            { 12, 75 },
            { 13, 85 },
            { 14, 75 },
            { 15, 75 },
            { 16, 245 },
            { 17, 85 },
            { 18, 245 },
            { 19, 85 },
            { 20, 85 },
            { 21, 75 },
            { 22, 245 },
            { 23, 75 },
            { 24, 245 },
            { 25, 75 },
            { 26, 75 },
            { 27, 245 },
            { 28, 85 },
            { 29, 75 },
            { 30, 245 },
            { 31, 245 },
            { 32, 75 },
            { 33, 85 },
            { 34, 85 },
            { 35, 245 },
            { 36, 85 },
            { 37, 95 },
            { 38, 95 },
            { 39, 85 },
            { 40, 245 },
            { 41, 175 },
            { 42, 150 },
            { 43, 85 },
            { 44, 150 },
            { 45, 245 },
            { 46, 150 },
            { 47, 150 },
            { 48, 150 },
            { 49, 150 },
            { 50, 245 },
            { 51, 95 },
            { 52, 135 },
            { 53, 85 },
            { 54, 150 },
            { 55, 150 },
            { 56, 150 },
            { 57, 95 },
            { 58, 150 },
            { 59, 85 },
            { 60, 85 },
            { 61, 85 },
            { 62, 115 },
            { 63, 85 },
            { 64, 85 },
            { 65, 85 },
            { 66, 115 },
            { 67, 150 },
            { 68, 245 },
            { 69, 150 },
            { 70, 150 },
            { 71, 115 },
            { 72, 150 },
            { 73, 150 },
            { 74, 150 },
            { 75, 85 },
            { 76, 125 },
            { 77, 150 },
            { 78, 125 },
            { 79, 125 },
            { 80, 85 },
            { 81, 245 },
            { 82, 245 },
            { 83, 150 },
            { 84, 150 },
            { 85, 125 },
            { 86, 150 },
            { 87, 125 },
            { 88, 125 },
            { 89, 150 },
            { 90, 125 },
            { 91, 85 },
            { 92, 125 },
            { 93, 150 },
            { 94, 150 },
            { 95, 150 },
            { 96, 175 },
            { 97, 135 },
            { 98, 150 },
            { 99, 245 },
            { 100, 85 },
            { 101, 150 },
            { 102, 150 },
            { 103, 85 },
            { 104, 135 },
            { 105, 150 },
            { 106, 85 },
            { 107, 85 },
            { 108, 150 },
            { 109, 175 },
            { 110, 175 },
            { 111, 150 },
            { 112, 175 },
            { 113, 175 },
            { 114, 175 },
            { 115, 175 },
            { 116, 150 },
            { 117, 150 },
            { 118, 125 },
            { 119, 175 },
            { 120, 175 },
            { 121, 175 },
            { 122, 175 },
            { 123, 175 },
            { 124, 175 },
            { 125, 175 },
            { 126, 150 },
            { 127, 150 },
            { 128, 175 },
            { 129, 175 },
            { 130, 130 },
            { 131, 175 },
            { 132, 200 },
            { 133, 175 },
            { 134, 200 },
            { 135, 175 },
            { 136, 130 },
            { 137, 200 },
            { 138, 200 },
            { 139, 200 },
            { 140, 135 },
            { 141, 135 },
            { 142, 200 },
            { 143, 200 },
            { 144, 165 },
            { 145, 140 },
            { 146, 200 },
            { 147, 145 },
            { 148, 145 },
            { 149, 150 },
            { 150, 225 },
            { 151, 150 },
            { 152, 200 },
            { 153, 165 },
            { 154, 135 },
            { 155, 135 },
            { 156, 275 },
            { 157, 200 },
            { 158, 300 },
            { 159, 300 },
            { 160, 350 },
            { 161, 135 },
            { 162, 135 },
            { 163, 145 },
            { 164, 145 },
            { 165, 145 },
            { 166, 165 },
            { 167, 165 }
        };

        public List<int> MaxPassengers = new List<int>()
        {
            4,
            6,
            10,
            20,
            50,
            12,
            61,
            40,
            20,
            40,
            73,
            30,
            80,
            2,
            0
        };

        public static int Passengers
        {
            get;
            set;
        }

        public static List<string> PossibleVehicles
        {
            get;
            set;
        }

        public static string RawVehicle
        {
            get;
            set;
        }

        public static string Vehicle
        {
            get;
            set;
        }

        public VehicleMatcher()
        {
        }
    }
}