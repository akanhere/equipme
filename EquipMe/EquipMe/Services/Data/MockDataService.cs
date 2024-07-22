using System;
using System.Collections.ObjectModel;
using EquipMe.Models;


namespace EquipMe.Services.Data
{
	public class MockDataService:IDataService
	{
        List<Round> _rounds = new List<Round>();

        public MockDataService()
		{
		}

        public IEnumerable<Round> GetRoundsAsync()
        {

            if (_rounds.Count > 0)
                return _rounds;

            var r1 = new Round { Name = "Mock Round 1" };
            var p1 = new Parameter { Name = "Numeric 1", Type = "Numeric", Value = "" };
            var p2 = new Parameter { Name = "Parameter 2", Type = "Dropdown", Value = new ObservableCollection<string> { "OK", "NOT OK" } };
            var e1 = new Equipment { Name = "Equipment 1", Parameters = new ObservableCollection<Parameter> { p1, p2 } };
            r1.Equipments = new ObservableCollection<Equipment> { e1 };

            var r2 = new Round { Name = "Mock Round 2" };
            var p3 = new Parameter { Name = "Numeric 2", Type = "Numeric", Value = "" };
            var p4 = new Parameter { Name = "Parameter 4", Type = "Dropdown", Value = new ObservableCollection<string> { "YES", "NO" } };
            var e2 = new Equipment { Name = "Equipment 2", Parameters = new ObservableCollection<Parameter> { p3, p4 } };
            r2.Equipments = new ObservableCollection<Equipment> { e2 };

            var r3 = new Round { Name = "Mock Round 3" };
            var p5 = new Parameter { Name = "Numeric 3", Type = "Numeric", Value = "" };
            var p6 = new Parameter { Name = "Parameter 6", Type = "MultipleSelection", Value = new ObservableCollection<string> { "HIGH", "MEDIUM", "LOW" } };
            var e3 = new Equipment { Name = "Equipment 3", Parameters = new ObservableCollection<Parameter> { p5, p6 } };
            r3.Equipments = new ObservableCollection<Equipment> { e3 };


            var r4 = new Round { Name = "Mock Round 4" };
            var equipments = new ObservableCollection<Equipment>();

            for (int i = 1; i <= 5; i++)
            {
                var parameters = new ObservableCollection<Parameter>
            {
                new Parameter { Name = $"Numeric {i}", Type = "Numeric", Value = "" },
                new Parameter { Name = $"Parameter {i}", Type = "Dropdown", Value = new ObservableCollection<string> { "OK", "NOT OK" } },
                new Parameter { Name = $"Parameter {i+10}", Type = "Date", Value = new ObservableCollection<string> { "YES", "NO" } }
            };

                var equipment = new Equipment { Name = $"Equipment {i}", Parameters = parameters };
                equipments.Add(equipment);
            }

            r4.Equipments = equipments;


            _rounds.Add(r1);
            _rounds.Add(r2);
            _rounds.Add(r3);
            _rounds.Add(r4);
            

            return _rounds;
        }

        public Round GetRoundByName(string name)
        {
            var round = _rounds.FirstOrDefault(r => r.Name == name);
            return round;
        }
    }
}

