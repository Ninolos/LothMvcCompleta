function SetModal() {
    var modalLinks = document.querySelectorAll('a[data-modal]');
    modalLinks.forEach(function (link) {
        link.addEventListener('click', function (event) {
            event.preventDefault(); // impede que o link execute sua ação padrão

            var url = this.href; // obtém a URL do link
            var xhr = new XMLHttpRequest(); // cria um objeto XMLHttpRequest

            xhr.onload = function () {
                if (xhr.status === 200) { // verifica se a requisição foi bem-sucedida
                    var modalContent = document.getElementById('myModalContent');
                    modalContent.innerHTML = xhr.responseText; // define o conteúdo do modal
                    var modal = new bootstrap.Modal(document.getElementById('myModal')); // cria uma nova instância do modal do Bootstrap
                    modal.show(); // exibe o modal
                    bindForm(modalContent); // vincula o formulário ao modal
                }
            };

            xhr.open('GET', url);
            xhr.send();
        });
    });
}

function bindForm(dialog) {
    var forms = dialog.getElementsByTagName('form');
    for (var i = 0; i < forms.length; i++) {
        forms[i].addEventListener('submit', function (event) {
            event.preventDefault(); // impede que o formulário execute sua ação padrão

            var xhr = new XMLHttpRequest(); // cria um objeto XMLHttpRequest

            xhr.onload = function () {
                if (xhr.status === 200) { // verifica se a requisição foi bem-sucedida
                    var result = JSON.parse(xhr.responseText);
                    if (result.success) {
                        var modal = new bootstrap.Modal(document.getElementById('myModal'));
                        modal.hide(); // esconde o modal
                        var enderecoTarget = document.getElementById('EnderecoTarget');
                        enderecoTarget.innerHTML = result.url; // define o conteúdo retornado na div EnderecoTarget
                    } else {
                        var modalContent = document.getElementById('myModalContent');
                        modalContent.innerHTML = result;
                        bindForm(dialog);
                    }
                }
            };

            xhr.open(this.method, this.action);
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.send(new FormData(this));
            SetModal();
            return false;
        });
    }
}

function fecharModal() {
    var modal = document.getElementById('myModal');
    var backdrop = document.getElementsByClassName('modal-backdrop')[0];
    modal.style.display = 'none';
    backdrop.style.display = 'none';
}

function BuscaCep() {
    var cepInput = document.getElementById('Endereco_Cep');
    var logradouroInput = document.getElementById('Endereco_Logradouro');
    var bairroInput = document.getElementById('Endereco_Bairro');
    var cidadeInput = document.getElementById('Endereco_Cidade');
    var estadoInput = document.getElementById('Endereco_Estado');

    function limpa_formulário_cep() {
        logradouroInput.value = '';
        bairroInput.value = '';
        cidadeInput.value = '';
        estadoInput.value = '';
    }

    cepInput.addEventListener('blur', function () {
        var cep = cepInput.value.replace(/\D/g, '');

        if (cep !== '') {
            var validacep = /^[0-9]{8}$/;

            if (validacep.test(cep)) {
                logradouroInput.value = '...';
                bairroInput.value = '...';
                cidadeInput.value = '...';
                estadoInput.value = '...';

                var xhr = new XMLHttpRequest();

                xhr.onload = function () {
                    if (xhr.status === 200) {
                        var dados = JSON.parse(xhr.responseText);

                        if (!dados.erro) {
                            logradouroInput.value = dados.logradouro;
                            bairroInput.value = dados.bairro;
                            cidadeInput.value = dados.localidade;
                            estadoInput.value = dados.uf;
                        } else {
                            limpa_formulário_cep();
                            alert('CEP não encontrado.');
                        }
                    }
                };

                xhr.open('GET', 'https://viacep.com.br/ws/' + cep + '/json/');
                xhr.send();
            } else {
                limpa_formulário_cep();
                alert('Formato de CEP inválido.');
            }
        } else {
            limpa_formulário_cep();
        }
    });
}

function SetMsgBox() {
    var msgBox = document.getElementById('msg_box');
    setTimeout(function () {
        msgBox.style.display = 'none';
    }, 2500);
}