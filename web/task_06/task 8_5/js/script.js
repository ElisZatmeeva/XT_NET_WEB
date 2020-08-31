window.addEventListener('DOMContentLoaded', function () {

    'use strict';

    //Buttons search
    const buttonSearch = document.querySelector('.search-container .button');
    //Input search
    const inputSearch = document.querySelector('.search input');


    // Window Create note
    const windowCreateNote = document.querySelector('.container-note[data-property]');
    // Field heading from window 'Create'
    const inputHead = document.querySelector('.header-note input');
    // Text of note
    const inputText = document.querySelector('.text-note[data-property]');

    // Buttons
    const btnClose = document.querySelector('.btn-note[data-action="close"]');

    // block for create new note
    const divNewCreateNote = document.querySelector('.create-new-note');

    let key;
    let value;

    //LOCALSTORAGE!!!

    let vault = {
        [key]: value,
    }

    vault[key] = value;

    function saveLocalStorage() {
        localStorage.setItem('vault', JSON.stringify(vault));
        let unpacking = localStorage.getItem('vault');
        unpacking = JSON.parse(unpacking);
        console.log(unpacking);
    }

    function createNewNote() {
        let newDivNote = windowCreateNote.cloneNode(true);
        windowCreateNote.after(newDivNote);
        //Delete button create

        let newDivButton = newDivNote.querySelector('.btn-note[data-action="close"]').classList.add('hide');

        newDivNote.dataset.property = "new";
        let addClassBtn = newDivNote.querySelector('.btn-note');
        addClassBtn.dataset.action = "drop";
        addClassBtn.classList.add("drop");
        addClassBtn.querySelector('button').innerText = '';

        for (let name of newDivNote.children) {
            name.setAttribute('data-action', 'drop');
        }

        for (let name of newDivNote.children) {
            name.setAttribute('data-property', 'new');
        }
    }


    function dropNote(target) {

        let dropNoteLet = target.parentElement.parentElement;
        //reading text field
        let key = dropNoteLet.querySelector('.header-note input').value;
        let value = dropNoteLet.querySelector('.header-note input').value;

        let confirmDrop = confirm(`Вы уверены, что хотите удалить заметку?`)

        if (confirmDrop) {
            if (vault.hasOwnProperty(key)) {
                delete vault[key];
                console.log(vault);
            }

            dropNoteLet.remove();
        }
    }

    function changeNote(target) {
        let changeNoteLet = target.parentElement.parentElement;
        let key = changeNoteLet.querySelector('.header-note input').value;
        let value = changeNoteLet.querySelector('.header-note input').value;
    }



    function toFind(sourceSerch, comparisonWith) {
        if (sourceSerch != '') {

            comparisonWith.forEach(function (elem) {

                let expr = new RegExp(sourceSerch, 'ig');
                console.log(elem.parentElement.parentElement);
                elem.parentElement.parentElement.classList.add('hide');

                if (elem.value.match(expr)) {

                    if (elem.parentElement.dataset.property !== 'create') {
                        elem.parentElement.parentElement.classList.remove('hide');

                    }
                }

            });


        } else {
            comparisonWith.forEach(function (elem) {
                if (elem.parentElement.dataset.property !== 'create') {

                    elem.parentElement.parentElement.classList.remove('hide');

                }
            });

        }
    }

    // Event for button Close
    btnClose.onclick = (event) => {
        event.preventDefault();
        windowCreateNote.classList.add('hide');
        windowCreateNote.querySelector('input').value = '';
        windowCreateNote.querySelector('.text-note').value = '';

    }

    //button appearance
    divNewCreateNote.onclick = (event) => {
        event.preventDefault();
        // windowCreateNote.style.display = "";
        windowCreateNote.classList.remove('hide');

    }

    // Delete note 
    event.target.onclick = (event) => {
        event.preventDefault();
        let target = event.target;
        // Delete note 
        if (target && target.classList.contains("drop")) {
            dropNote(target);
            saveLocalStorage();
        }

        // Close note if she is
        if (target && target.dataset.action == "close") {
            return target;
        }
        // Change note if she is
        if (target && target.dataset.action == "change") {
            let changeNote = target.parentElement.parentElement;
            let key = changeNote.querySelector('.header-note input').value;
            let value = changeNote.querySelector('.header-note input').value;
            let keyReserv = key;
            let valueReserve = value;

            if (vault.hasOwnProperty(key)) {
                delete vault[key];
                console.log(vault);

                // changeNote.remove();
                if (key && value) {
                    key = changeNote.querySelector('.header-note input').value;
                    value = changeNote.querySelector('.header-note input').value;
                    vault[key] = value;
                    // console.log(vault);

                    saveLocalStorage();

                    let newDivNote = windowCreateNote.cloneNode(true);

                    windowCreateNote.after(newDivNote);
                    //Delete button create
                    console.log(newDivNote.querySelector('.container-note'));
                    newDivNote.classList.remove('hide');

                    let addClassBtn = newDivNote.querySelector('.btn-note');
                    addClassBtn.dataset.action = "change";

                    for (let name of newDivNote.children) {
                        name.setAttribute('data-action', 'change');
                    }

                    for (let name of newDivNote.children) {
                        name.setAttribute('data-property', 'change');
                    }
                }
            }
        }


        //Кликать по пустому полю, рядом с корзиной.

        if (target && target.dataset.property == 'new') {
            // // Изменение панели кнопок

            target.firstElementChild.dataset.action = "change";
            target.firstElementChild.innerHTML = "Создать";
            target.dataset.action = "change";
            target.firstElementChild.classList.remove('drop');
            console.log(target.firstElementChild);
            target.lastElementChild.classList.remove('hide');

        }
    }


    //Change note
    windowCreateNote.onclick = (event) => {

        event.preventDefault();
        let target = event.target;

        if (target == 'div.functional-note-btn' && target.dataset.property == 'new') {

            target.firstElementChild.dataset.action = "change";
            target.firstElementChild.innerHTML = "Создать";
            target.firstElementChild.classList.remove('drop');
            target.dataset.property = "change";
            target.lastElementChild.dataset.action = "change";
            target.querySelector('.btn-note[data-attribute="close"]').classList.remove('hide');

        }

        if (target.dataset.action == 'create') {
            event.preventDefault();

            key = inputHead.value;
            value = inputText.value;

            if (key && value) {

                vault[key] = value;
                saveLocalStorage();
                createNewNote();
                inputHead.value = '';
                inputText.value = '';
                windowCreateNote.classList.add('hide');

            } else {
                alert('Для создания заметки заполните все поля');
            }

        }
        if (target.dataset.action == 'close') {

            target.classList.add('hide');

        }
        if (target.dataset.action == 'drop') {
            dropNote(target);
            saveLocalStorage();

        }
    }

    buttonSearch.onclick = (event) => {
        let target = event.target;
        event.preventDefault();

        let textFromSerchInput = inputSearch.value.trim();
        let textFromNoteInput = document.querySelectorAll('.container-note input');
        let textFromNoteTextearea = document.querySelectorAll('.container-note textarea');

        toFind(textFromSerchInput, textFromNoteInput);

    }
});