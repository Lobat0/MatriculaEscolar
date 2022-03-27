/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * Formatação dos campos
 */

$(function(){
    
    $("[data-mask]").inputmask();
   
    $(".dateptbr").datepicker({
        minDate: '-120Y',
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo','Segunda','Terça','Quarta','Quinta','Sexta','Sábado'],
        dayNamesMin: ['D','S','T','Q','Q','S','S','D'],
        dayNamesShort: ['Dom','Seg','Ter','Qua','Qui','Sex','Sáb','Dom'],
        monthNames: ['Janeiro','Fevereiro','Março','Abril','Maio','Junho','Julho','Agosto','Setembro','Outubro','Novembro','Dezembro'],
        monthNamesShort: ['Jan','Fev','Mar','Abr','Mai','Jun','Jul','Ago','Set','Out','Nov','Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });
    
    $(".dateptbr").blur(function() {
        var datanasc = $(".dateptbr").val();
        var res = datanasc.split("/");
        var ano = res[2];
        if(ano < "1900" || ano > "2017" ){
            $(".dateptbr").val(res[0]+"/"+res[1]+"/");
            return false;
        }
    });
    
    
    $(".real").maskMoney({
        prefix:'R$: ', 
        allowNegative: true, 
        thousands:'.', 
        decimal:',', 
        affixesStay: true
    });
    
    $(".btnMudarSenhaUsuario").click(function (e){
        var idUsuario = $(this).attr("novoId");
        var senha = $("[name='senha"+idUsuario+"']").val();
        var csenha = $("[name='csenha"+idUsuario+"']").val();
        if(senha !== csenha){
            alert("Erro... Campo Senha diverge da Confirmar Senha");
            return false;
        }
    });
    
    $("#btnMudarSenha").click(function (e){
        var senha = $("[name='senha']").val();
        var csenha = $("[name='csenha']").val();
        if(senha !== csenha){
            alert("Erro... Campo Senha diverge da Confirmar Senha");
            return false;
        }
    });
    
});
