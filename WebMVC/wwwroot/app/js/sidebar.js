function initSidebar() {
    let pages = document.body.querySelectorAll("a[data-page*='Page'");
    
    pages.forEach(x => {
        x.addEventListener('click', (e) => {
            let attr = e.target.getAttribute('data-page');
            setPageByAttribute(attr);
        });
    });
}