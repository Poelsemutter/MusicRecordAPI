using MusicRecordAPI.Repositories;
using MusicRecordAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecordTest
{
    [TestClass]
    public class RecordTests
    {
        private RecordRepository _repo;

        [TestInitialize]
        public void Init()
        {
            _repo = new RecordRepository(new List<Record>());
            _repo.AddRecord(new Record("Abbey Road", "The Beatles", 2600, 1969));
            _repo.AddRecord(new Record("The Dark Side of the Moon", "Pink Floyd", 2580, 1973));
            _repo.AddRecord(new Record("Thriller", "Michael Jackson", 2580, 1982));
            _repo.AddRecord(new Record("Back in Black", "AC/DC", 2550, 1980));
            _repo.AddRecord(new Record("Rumours", "Fleetwood Mac", 2400, 1977));
        }

        [TestMethod]
        public void GetAllRecord_ReturnsAllRecords()
        {
            // Act
            var result = _repo.GetAllRecords();

            // Assert
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void GetRecordById_ReturnsCorrectId()
        {
            // Act
            var result = _repo.GetRecordById(2);

            // Assert
            Assert.AreEqual(2, result.Id);
        }

        [TestMethod]
        public void UpdateRecord_ExistingId_ReturnsUpdatedRecord()
        {
            // Arrange
            var newRecord = new Record("Highway to Hell", "AC/DC", 2500, 1979) { Id = 4 };

            // Act
            var result = _repo.UpdateRecord(newRecord);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Highway to Hell", result.Title);
            Assert.AreEqual("Highway to Hell", _repo.GetRecordById(4).Title);
        }

        [TestMethod]
        public void UpdateRecord_ReturnsNull()
        {
            // Arrange
            var newRecord = new Record("Highway to Hell", "AC/DC", 2500, 1979) { Id = 999 };

            // Act
            var result = _repo.UpdateRecord(newRecord);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddRecord_SetsCorrectId()
        {
            // Arrange
            var newRecord = new Record("Highway to Hell", "AC/DC", 2500, 1979);

            // Act
            var result = _repo.AddRecord(newRecord);

            // Assert
            Assert.AreEqual(6, result.Id);
        }

        [TestMethod]
        public void DeleteRecord_DeletesCorrectRecord()
        {
            // Act 
            var result = _repo.DeleteRecord(3);

            // Assert
            Assert.IsNull(_repo.GetRecordById(3));
            Assert.AreEqual(4, _repo.GetAllRecords().Count());
        }

        [TestMethod]
        public void DeleteRecord_NonExistingId_ReturnsNull()
        {
            // Act
            var result = _repo.DeleteRecord(999);

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(5, _repo.GetAllRecords().Count());
        }
    }
}
