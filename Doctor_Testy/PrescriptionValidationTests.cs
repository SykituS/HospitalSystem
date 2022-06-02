using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Doctor;
using FluentValidation.Results;

namespace Doctor_Testy
{
    [TestClass]
    public class PrescriptionValidationTests
    {
        [TestMethod]
        public void ISValid()
        {
            string medicine = "medicine";
            string dosage = "dawka";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void MedicineIsEmpty()
        {
            string medicine = "";
            string dosage = "dawka";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void DosageIsEmpty()
        {
            string medicine = "medicine";
            string dosage = "";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void BothAreEmpty()
        {
            string medicine = "";
            string dosage = "";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void MedicineContainsNoValidChars()
        {
            string medicine = "@{}";
            string dosage = "dosage";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void DosageContainsNoValidChars()
        {
            string medicine = "medicine";
            string dosage = "@{}";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void BothContainsNoValidChars()
        {
            string medicine = "@{}";
            string dosage = "@{}";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void MedicineIsTooLong()
        {
            string medicine = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            string dosage = "dosage";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void DosageIsTooLong()
        {
            string medicine = "medicine";
            string dosage = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void BothAreTooLong()
        {
            string medicine = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            string dosage = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

            Prescription prescription = new Prescription(medicine, dosage);

            Prescription_Validation validator = new Prescription_Validation();

            ValidationResult result = validator.Validate(prescription);

            Assert.AreEqual(false, result.IsValid);
        }

    }
}
