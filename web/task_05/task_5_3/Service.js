
// for mentor: check it in your browser

'use strict';
class Service {                   
    constructor (name, age, gender){ 

        this.name = name;
        this.age = age;
        this.gender = gender;

    }

    add(obj) {
    this.propertyObj = {};
        for(let item in obj) {
            this.propertyObj[item] = obj[item];
            }    
        }

    getById(id) {
        if(id in this){
            // console.log(this);
            return this;
           
        } else {
            return null;
        }
        
    }   

    getAll() {
        let map = new Map(Object.entries(this));
        console.log(map);
        }

    deleteById(id) {
        if(id in this.propertyObj){
            let retObj = this.propertyObj;
            delete this.propertyObj;
            //console.log(retObj);
            return retObj;           
        }
        if(id in this){
            let spareObj = this;
            delete this;
            return spareObj; 
           
        }
    }

    updateById(id, obj){
       if(id in this){
            for (let prop in obj) {
                if(id === prop){
                    this[id] = obj[prop];
                    console.log(this);
                }
            }
        } else {
            console.log(`Обновление не возможно. Идентификатор не существует объекте`);
        }
    }

    replaceById(id, obj){
        if(id in this){
            storage = Object.assign(storage, obj);  
            console.log(storage);     
        }
    }
}

