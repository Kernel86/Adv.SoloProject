using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CCustomer
    {
        // Private Fields
        private int _iCustomerId;
        private string _sAccountNumber;
        private string _sFirstName;
        private string _sLastName;
        private string _sAddress;
        private string _sCity;
        private string _sState;
        private string _sZip;
        private string _sPhone;
        private string _sEmail;
        private DateTime _dtDateOfBirth;
        private int _iCustomerStatusId;

        // Public Properties
        public int CustomerId
        {
            get { return _iCustomerId; }
            set { _iCustomerId = value; }
        }

        public string AccountNumber
        {
            get { return _sAccountNumber; }
            set { _sAccountNumber = value; }
        }

        public string FirstName
        {
            get { return _sFirstName; }
            set { _sFirstName = value; }
        }

        public string LastName
        {
            get { return _sLastName; }
            set { _sLastName = value; }
        }

        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        public string City
        {
            get { return _sCity; }
            set { _sCity = value; }
        }
        public string State
        {
            get { return _sState; }
            set { _sState = value; }
        }
        public string Zip
        {
            get { return _sZip; }
            set { _sZip = value; }
        }
        public string Phone
        {
            get { return _sPhone; }
            set { _sPhone = value; }
        }
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _dtDateOfBirth; }
            set { _dtDateOfBirth = value; }
        }

        public int CustomerStatusId
        {
            get { return _iCustomerStatusId; }
            set { _iCustomerStatusId = value; }
        }

        // Constructors
        public CCustomer()
        {

        }

        public CCustomer(tblCustomer otblCustomer)
        {
            _iCustomerId = otblCustomer.Customer_Id;
            _sAccountNumber = otblCustomer.AccountNumber;
            _sFirstName = otblCustomer.FirstName;
            _sLastName = otblCustomer.LastName;
            _sAddress = otblCustomer.Address;
            _sCity = otblCustomer.City;
            _sState = otblCustomer.State;
            _sZip = otblCustomer.Zip;
            _sPhone = otblCustomer.Phone;
            _sEmail = otblCustomer.Email;
            _dtDateOfBirth = (DateTime)otblCustomer.DateOfBirth;
            _iCustomerStatusId = otblCustomer.CustomerStatus_Id;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblCustomer otblCustomer = new tblCustomer();

                otblCustomer.Customer_Id = CustomerId;
                otblCustomer.AccountNumber = AccountNumber;
                otblCustomer.FirstName = FirstName;
                otblCustomer.LastName = LastName;
                otblCustomer.Address = Address;
                otblCustomer.City = City;
                otblCustomer.State = State;
                otblCustomer.Zip = Zip;
                otblCustomer.Phone = Phone;
                otblCustomer.Email = Email;
                otblCustomer.DateOfBirth = DateOfBirth;
                otblCustomer.CustomerStatus_Id = CustomerStatusId;

                oDc.tblCustomers.InsertOnSubmit(otblCustomer);
                oDc.SubmitChanges();
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblCustomer otblCustomer = (from c in oDc.tblCustomers
                                            where c.Customer_Id == CustomerId
                                            select c).FirstOrDefault();

                FirstName = otblCustomer.FirstName;
                LastName = otblCustomer.LastName;
                Address = otblCustomer.Address;
                City = otblCustomer.City;
                State = otblCustomer.State;
                Zip = otblCustomer.Zip;
                Phone = otblCustomer.Phone;
                Email = otblCustomer.Email;
                CustomerStatusId = otblCustomer.CustomerStatus_Id;

                oDc.SubmitChanges();
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblCustomer otblCustomer = (from c in oDc.tblCustomers where c.Customer_Id == CustomerId select c).FirstOrDefault();

                oDc.tblCustomers.DeleteOnSubmit(otblCustomer);
                oDc.SubmitChanges();

                otblCustomer = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
