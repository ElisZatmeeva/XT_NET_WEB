let storage = new Service("Petya", 15, "man");

let newObj = { // object as property
    growth : 186,
    weight : 100,  
    sport : 'yes'  
}

let otherObj = {
    name : 'Fred',
    age : 18,
    gender : 'man'
}

storage.add(newObj);
storage.getAll();
// storage.getById('name');
// storage.getById('Blah');
storage.deleteById('sport');
// storage.updateById('name', otherObj);
// storage.replaceById('gender', otherObj);
// console.log(storage);