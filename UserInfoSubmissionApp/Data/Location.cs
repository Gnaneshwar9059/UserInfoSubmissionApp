namespace UserInfoSubmissionApp.Data;

public static class LocationData
{
    public static IReadOnlyList<string> GetCountries() =>
    [
        "Australia",
        "Canada",
        "France",
        "Germany",
        "India",
        "Japan",
        "Mexico",
        "Singapore",
        "United Kingdom",
        "United States",
        "Other"
    ];

    public static IReadOnlyList<string> GetStates(string country) =>
        country switch
        {
            "United States" =>
            [
                "Alabama","Alaska","Arizona","Arkansas","California",
                "Colorado","Connecticut","Delaware","Florida","Georgia",
                "Hawaii","Idaho","Illinois","Indiana","Iowa",
                "Kansas","Kentucky","Louisiana","Maine","Maryland",
                "Massachusetts","Michigan","Minnesota","Mississippi","Missouri",
                "Montana","Nebraska","Nevada","New Hampshire","New Jersey",
                "New Mexico","New York","North Carolina","North Dakota","Ohio",
                "Oklahoma","Oregon","Pennsylvania","Rhode Island","South Carolina",
                "South Dakota","Tennessee","Texas","Utah","Vermont",
                "Virginia","Washington","West Virginia","Wisconsin","Wyoming"
            ],
            "India" =>
            [
                "Andhra Pradesh","Arunachal Pradesh","Assam","Bihar",
                "Chhattisgarh","Goa","Gujarat","Haryana","Himachal Pradesh",
                "Jharkhand","Karnataka","Kerala","Madhya Pradesh","Maharashtra",
                "Manipur","Meghalaya","Mizoram","Nagaland","Odisha",
                "Punjab","Rajasthan","Sikkim","Tamil Nadu","Telangana",
                "Tripura","Uttar Pradesh","Uttarakhand","West Bengal",
                "Delhi","Jammu and Kashmir","Ladakh","Puducherry"
            ],
            "Canada" =>
            [
                "Alberta","British Columbia","Manitoba","New Brunswick",
                "Newfoundland and Labrador","Northwest Territories","Nova Scotia",
                "Nunavut","Ontario","Prince Edward Island","Quebec",
                "Saskatchewan","Yukon"
            ],
            "Australia" =>
            [
                "Australian Capital Territory","New South Wales",
                "Northern Territory","Queensland","South Australia",
                "Tasmania","Victoria","Western Australia"
            ],
            "Germany" =>
            [
                "Baden-Württemberg","Bavaria","Berlin","Brandenburg","Bremen",
                "Hamburg","Hesse","Lower Saxony","Mecklenburg-Vorpommern",
                "North Rhine-Westphalia","Rhineland-Palatinate","Saarland",
                "Saxony","Saxony-Anhalt","Schleswig-Holstein","Thuringia"
            ],
            "United Kingdom" =>
            [
                "England","Northern Ireland","Scotland","Wales"
            ],
            _ => ["N/A"]
        };
}