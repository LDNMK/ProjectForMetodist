function initSidebar() {
    let pages = document.body.querySelectorAll("a[data-page*='-page'");
    let items = document.body.querySelectorAll(".sidebar__menu-item");
    
    pages.forEach(x => {
        x.addEventListener('click', (e) => {
            let attr = e.target.getAttribute('data-page');
            setPageByAttribute(attr);

            items.forEach(item => item.classList.remove('active'));
            e.target.closest('.sidebar__menu-item').classList.add('active');
        });
    });
}