// function för att hantera footer.
function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }

}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)



function toggleMenu(attribute) {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }
}
toggleMenu('[data-option="toggle"]')







//// Hantera footer så den hamnar i rätt läge om sidan är tom.

//try {
//    const footer = document.querySelector('footer')         // Leatar efter footer.

//    if (document.body.scrollHeight >= window.innerHeight) {
//        footer.classList.remove('position-fixed-bottom')
//        footer.classList.add('position-static')
//    } else {
//        footer.classList.remove('position-static')
//        footer.classList.add('position-fixed-bottom')
//    }
//}
//catch { }




const validate = (e, form = null) => {
    if (e.type === 'submit') {
        const errors = {}
        errors.name = validate_name(form.name)
        errors.email = validate_email(form.email)
        errors.comments = validate_comments(form.comments)
        return errors

    } else {
        const { id, value } = e.target
        switch (id) {
            case 'name':
                return validate_name(value)
            case 'email':
                return validate_email(value)
            case 'comments':
                return validate_comments(value)
        }
    }
}


const validate_name = (value) => {
    if (!value)
        return 'A name is required'
    else if (value.length < 2)
        return 'Must be a valid name'
    else
        return null
}

const validate_email = (value) => {
    const regex_email = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/

    if (!value)
        return 'An email address is required'
    else if (!regex_email.test(value))
        return 'Must be a valid email address'
    else
        return null
}

const validate_comments = (value) => {
    if (!value)
        return 'A comment is required'
    else if (value.length < 10)
        return 'Your comment must be at least 10 characters long'
    else
        return null
}

