function getGroupItemWithDeleteButton(groupName, groupId) {
    if (groupId == "" || groupName == "") {
        return null;
    }

    let item = document.createElement('li');
    item.classList.add('group__item');
    item.setAttribute('data-group-id', groupId);

    let delBtn = document.createElement('i');
    delBtn.classList.add('fas', 'fa-minus-square');
    delBtn.addEventListener('click', (e) => {
        e.target.closest('ul').removeChild(item);
    });

    let span = document.createElement('span');
    span.innerText = groupName;

    item.insertAdjacentElement('beforeend', delBtn);
    item.insertAdjacentElement('beforeend', span);

    return item;
}

function removeCurriculumRow(e) {
    let row = e.closest('.curriculum__table-row-data');
    row.remove();
}