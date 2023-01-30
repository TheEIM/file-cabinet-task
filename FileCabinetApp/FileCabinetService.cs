using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp
{
    public class FileCabinetService
    {
        private readonly List<FileCabinetRecord> list = new ();
        private readonly Dictionary<string, List<FileCabinetRecord>> firstNameDictionary = new Dictionary<string, List<FileCabinetRecord>>();
        private readonly Dictionary<string, List<FileCabinetRecord>> lastNameDictionary = new Dictionary<string, List<FileCabinetRecord>>();

        public int CreateRecord(string firstName, string lastName, DateTime dateOfBirth, short acceessLevel, decimal salary, char sex)
        {
            IsValidData(firstName, lastName, dateOfBirth, acceessLevel, salary, sex);

            var record = new FileCabinetRecord
            {
                Id = this.list.Count + 1,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                AccessLevel = acceessLevel,
                Salary = salary,
                Sex = char.ToUpper(sex, CultureInfo.InvariantCulture),
            };

            this.list.Add(record);

            // creating firstname Dictionary
            firstName = firstName.ToLower(CultureInfo.InvariantCulture);
            if (!this.firstNameDictionary.ContainsKey(firstName))
            {
                this.firstNameDictionary.Add(firstName, new List<FileCabinetRecord>());
            }

            this.firstNameDictionary[firstName].Add(record);

            // creating lastname Dictionary
            lastName = lastName.ToLower(CultureInfo.InvariantCulture);
            if (!this.lastNameDictionary.ContainsKey(lastName))
            {
                this.lastNameDictionary.Add(lastName, new List<FileCabinetRecord>());
            }

            this.lastNameDictionary[lastName].Add(record);
            return record.Id;
        }

        public FileCabinetRecord[] GetRecords()
        {
            return this.list.ToArray();
        }

        public int GetStat()
        {
            return this.list.Count;
        }

        public void EditRecord(int id, string firstName, string lastName, DateTime dateOfBirth, short acceessLevel, decimal salary, char sex)
        {
            if (id < 1 || id > this.list.Count)
            {
                throw new ArgumentException("This ID does not exist.");
            }
            else
            {
                IsValidData(firstName, lastName, dateOfBirth, acceessLevel, salary, sex);
            }

            this.list[id - 1].FirstName = firstName;
            this.list[id - 1].LastName = lastName;
            this.list[id - 1].DateOfBirth = dateOfBirth;
            this.list[id - 1].AccessLevel = acceessLevel;
            this.list[id - 1].Salary = salary;
            this.list[id - 1].Sex = sex;

            // editing firstname Dictionary
            firstName = firstName.ToLower(CultureInfo.InvariantCulture);
            if (!this.firstNameDictionary.ContainsKey(firstName))
            {
                this.firstNameDictionary.Add(firstName, new List<FileCabinetRecord>());
            }
            else if (this.firstNameDictionary.Remove(firstName, out List<FileCabinetRecord>? value))
            {
                value = value.Where(item => item.Id != id).ToList();
                this.firstNameDictionary.Add(firstName, value);
            }

            this.firstNameDictionary[firstName].Add(this.list[id - 1]);

            // editing lastname Dictionary
            lastName = lastName.ToLower(CultureInfo.InvariantCulture);
            if (!this.lastNameDictionary.ContainsKey(lastName))
            {
                this.lastNameDictionary.Add(lastName, new List<FileCabinetRecord>());
            }
            else if (this.lastNameDictionary.Remove(lastName, out List<FileCabinetRecord>? value))
            {
                value = value.Where(item => item.Id != id).ToList();
                this.lastNameDictionary.Add(lastName, value);
            }

            this.lastNameDictionary[lastName].Add(this.list[id - 1]);
        }

        public FileCabinetRecord[] FindByFirstName(string firstname)
        {
            firstname = firstname.ToLower(CultureInfo.InvariantCulture);
            return this.firstNameDictionary[firstname].ToArray();
        }

        public FileCabinetRecord[] FindByLastName(string lastname)
        {
            lastname = lastname.ToLower(CultureInfo.InvariantCulture);
            return this.lastNameDictionary[lastname].ToArray();
        }

        public FileCabinetRecord[] FindByDateOfBirth(string dateofbirth)
        {
            if (DateTime.TryParse(dateofbirth, out DateTime date))
            {
                return this.list.Where(record => date == record.DateOfBirth).ToArray();
            }

            return Array.Empty<FileCabinetRecord>();
        }

        private static void IsValidData(string firstName, string lastName, DateTime dateOfBirth, short acceessLevel, decimal salary, char sex)
        {
            if (firstName.Length < 2 || firstName.Length > 60 || firstName == null)
            {
                throw new ArgumentException("First name is invalid.");
            }
            else if (lastName.Length < 2 || lastName.Length > 60 || lastName == null)
            {
                throw new ArgumentException("Last name is invalid.");
            }
            else if (dateOfBirth < new DateTime(1950, 1, 1) || dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Date of birth is invalid.");
            }
            else if (acceessLevel < 0 || acceessLevel > 100)
            {
                throw new ArgumentException("This level does not existing.");
            }
            else if (salary < 0)
            {
                throw new ArgumentException("Invalid salary value.");
            }
            else if (!(sex.Equals('M') || sex.Equals('W')))
            {
                throw new ArgumentException("This level does not existing.");
            }
        }
    }
}
