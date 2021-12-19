
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Role
{
    public class CreateRoleInput
    {

        public int ID { get; set; }
        public string NAME { get; set; }
        //interface IRole
        //{
        //    void DriveCar();
        //}

        //public class ProxyCar : IRole
        //{
        //    private ROLE role;
        //    private IRole realCar;

        //    public ProxyCar(RoleDTO roles)
        //    {
        //        this.role = roles;
        //        this.realCar = new Car();
        //    }

        //    public void DriveCar()
        //    {
        //        if (driver.Age < 16)
        //            Console.WriteLine("Sorry, the driver is too young to drive.");
        //        else
        //            this.realCar.DriveCar();
        //    }
        //}

    }
    public class UpdateRoleInput : CreateRoleInput
    {

    }
}