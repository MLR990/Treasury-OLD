// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $('#addTransaction').on('click', function(){
var transactionAmount = $('#transactionAmount').val();
var desc = $('#transactionDescription').val();
        $.post('AddTransaction', {amount: transactionAmount, description: desc});
    });
