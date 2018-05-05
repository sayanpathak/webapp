using System.Collections.Generic;
using System.IO;

namespace RankingAndRelevance
{
    class Program
    {
        static void Main()
        {
            List<Patient> patients = ReadPatients("Files\\Patient.tsv");
            List<Member> members = ReadMembers("Files\\Member.tsv");
            List<PlaceOfService> placeOfServices = ReadPlaceOfService("Files\\PlaceOfService.tsv");
            List<Provider> providers = ReadProviders("Files\\Provider.tsv");
        }

        public static List<PlaceOfService> ReadPlaceOfService(string path)
        {
            List<PlaceOfService> places = new List<PlaceOfService>();
            return places;
        }

        public static List<Member> ReadMembers(string path)
        {
            List<Member> members = new List<Member>();
            return members;
        }

        public static List<Provider> ReadProviders(string path)
        {
            List<Provider> providers = new List<Provider>();
            return providers;
        }

        public static List<Patient> ReadPatients(string path)
        {
            var lines = File.ReadLines(path);
            int lineCounter = 0;
            List<Patient> patients = new List<Patient>();
            foreach (string line in lines)
            {
                if (lineCounter == 0)
                {
                    lineCounter++;
                    continue; //skip header
                }

                string[] columns = line.Split('\t');
                string patientRelCode = columns[0];
                string patientLast = columns[1];
                string patientFirst = columns[2];
                string patientMiddle = columns[3];
                string patientDob = columns[4];
                string patientSex = columns[5];
                string patientMaritalStatus = columns[6];
                string patientAddressLine1 = columns[7];
                string patientAddressLine2 = columns[8];
                string patientCity = columns[9];
                string patientState = columns[10];
                string patientZip = columns[11];
                string keywords = columns[12];

                Patient p = new Patient
                {
                    PatientRelCode = patientRelCode,
                    PatientLast = patientLast,
                    PatientFirst = patientFirst,
                    PatientMiddle = patientMiddle,
                    PatientDOB = patientDob,
                    PatientSex = patientSex,
                    PatientMaritalStatus = patientMaritalStatus,
                    PatientAddressLine1 = patientAddressLine1,
                    PatientAddressLine2 = patientAddressLine2,
                    PatientCity = patientCity,
                    PatientState = patientState,
                    PatientZip = patientZip,
                    Keywords = keywords,
                };

                patients.Add(p);
                lineCounter++;
            }
            return patients;
        }
    }
}
