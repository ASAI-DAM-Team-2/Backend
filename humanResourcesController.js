const Employee = require('../models/Employee')

module.exports = {

  async getAllWithJobId(id) {
      try {
          return { successful: true, res: await Employee.findAll().filter(e => e.job_id == id) };
      } catch (e) {
          console.error("\nA server error occured\n\n", e);
          return { successful: false, error: e };
      }
  },

  async getAllWithPhones(){
    try {
        return { successful: true, res: await Employee.findAll().filter(e => e.phone != null) };
    } catch (e) {
        console.error("\nA server error occured\n\n", e);
        return { successful: false, error: e };
    }
  },

  async getAllWithoutPhones(){
    try {
        return { successful: true, res: await Employee.findAll().filter(e => e.phone == null) };
    } catch (e) {
        console.error("\nA server error occured\n\n", e);
        return { successful: false, error: e };
    }
  },

  async getAllWithEmail(){
    try {
        return { successful: true, res: await Employee.findAll().filter(e => e.email != null) };
    } catch (e) {
        console.error("\nA server error occured\n\n", e);
        return { successful: false, error: e };
    }
  },

  async getAllWithoutEmail(){
    try {
        return { successful: true, res: await Employee.findAll().filter(e => e.email == null) };
    } catch (e) {
        console.error("\nA server error occured\n\n", e);
        return { successful: false, error: e };
    }
  },
}                                                                            