using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class ManagerAuthTestCaseSource
    {
        public static IEnumerable AddManagerTestCaseSource()
        {
            ManagerAuthInput managerAuthInput = new ManagerAuthInput("Gera", "xxx");
            ManagerDto managerDtoInput = new ManagerDto()
            {
                Login = "Gera",
                Password = "xxx"
            };
            ManagerDto requestManagerByLogin = null;
            int result = 100;
            int expected = 100;

            yield return new object[] { managerAuthInput, managerDtoInput, requestManagerByLogin, result, expected };
        }

        public static IEnumerable AddManagerNegativeTestCaseSource()
        {
            ManagerAuthInput managerAuthInput = new ManagerAuthInput("Gera", "xxx");
            ManagerDto managerDtoInput = new ManagerDto()
            {
                Login = "Gera",
                Password = "xxx"
            };
            ManagerDto requestManagerByLogin = new ManagerDto()
            {
                Id = 100,
                Login = "Gera",
                Password = "xxx"
            };
            int expected = -1;

            yield return new object[] { managerAuthInput, managerDtoInput, requestManagerByLogin, expected };

            managerAuthInput.Password = null;
            managerDtoInput.Password = null;
            requestManagerByLogin = null;

            yield return new object[] { managerAuthInput, managerDtoInput, requestManagerByLogin, expected };

            managerAuthInput.Login = null;
            managerDtoInput.Login = null;

            yield return new object[] { managerAuthInput, managerDtoInput, requestManagerByLogin, expected };
        }

        public static IEnumerable ManagerAuthenticationTestCaseSourse()
        {
            ManagerAuthInput managerAuthInput = new ManagerAuthInput("Gera", "xxx");
            ManagerDto managerDtoInput = new ManagerDto()
            {
                Login = "Gera",
                Password = "xxx"
            };
            ManagerDto managerDtoOutput = new ManagerDto()
            {
                Id = 1,
                Login = "Gera",
                Password = "xxx"
            };
            CurrentManager expected = new CurrentManager(1, "Gera", "xxx");

            yield return new object[] { managerAuthInput, managerDtoInput, managerDtoOutput, expected };

            managerAuthInput.Password = "qqq";
            managerDtoInput.Password = "qqq";
            managerDtoOutput = null;
            expected = null;

            yield return new object[] { managerAuthInput, managerDtoInput, managerDtoOutput, expected };

            managerAuthInput.Login = "Goga";
            managerDtoInput.Login = "Goga";

            yield return new object[] { managerAuthInput, managerDtoInput, managerDtoOutput, expected };

            managerAuthInput.Password = "xxx";
            managerDtoInput.Password = "xxx";

            yield return new object[] { managerAuthInput, managerDtoInput, managerDtoOutput, expected };

            managerAuthInput.Login = "";
            managerDtoInput.Login = "";
            managerDtoOutput = null;
            expected = null;

            yield return new object[] { managerAuthInput, managerDtoInput, managerDtoOutput, expected };

            managerAuthInput = new ManagerAuthInput("Gera", "");
            managerDtoInput = new ManagerDto()
            {
                Login = "Gera",
                Password = ""
            };
            managerDtoOutput = new ManagerDto()
            {
                Id = 1,
                Login = "Gera",
                Password = ""
            };
            expected = new CurrentManager(1, "Gera", "");

            yield return new object[] { managerAuthInput, managerDtoInput, managerDtoOutput, expected };
        }

        public static IEnumerable UpdateManagerTestCaseSource()
        {
            CurrentManager currentManager = new CurrentManager(1, "Gera", "qwe");
            ManagerDto managerDtoInput = new ManagerDto()
            {
                Id = 1,
                Login = "Gera",
                Password = "qwe"
            };
            bool result = true;
            bool expected = true;

            yield return new object[] { currentManager, managerDtoInput, result, expected };

            currentManager.Id = 0;
            managerDtoInput.Id = 0;
            result = false;
            expected = false;

            yield return new object[] { currentManager, managerDtoInput, result, expected };
        }
    }
}