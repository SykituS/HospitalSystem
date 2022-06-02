using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Doctor;
using FluentValidation.Results;

namespace Doctor_Testy
{
    [TestClass]
    public class ReferralValidationTests
    {
        [TestMethod]
        public void ISValid()
        {
            string referral = "referral";

            Referrals referrals = new Referrals(referral);

            Referral_Validation validator = new Referral_Validation();

            ValidationResult result = validator.Validate(referrals);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ReferralContainsNoValidChars()
        {
            string referral = "{}!@";

            Referrals referrals = new Referrals(referral);

            Referral_Validation validator = new Referral_Validation();

            ValidationResult result = validator.Validate(referrals);

            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void ReferralTooLong()
        {
            string referral = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

            Referrals referrals = new Referrals(referral);

            Referral_Validation validator = new Referral_Validation();

            ValidationResult result = validator.Validate(referrals);

            Assert.AreEqual(false, result.IsValid);
        }
    }
}
