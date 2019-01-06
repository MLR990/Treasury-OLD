// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $('#addTransaction').on('click', function(){
        var transactionAmount = $('#transactionAmount').val();
        var desc = $('#transactionDescription').val();
        $.post('AddTransaction', {amount: transactionAmount, description: desc});
    });

    $('#addVendor').on('click', function(){
        var name = $('#vendorName').val();
        $.post('AddVendor', {vendorName: name});
    });

    $('#addCoffer').on('click', function(){
        var name = $('#cofferName').val();
        var amount = $('#cofferAmount').val();
        var order = $('#cofferOrder').val();
        var necessary =  $("#cofferNecessary").prop('checked');

        var desc =  $("#cofferDescription").val();

        var type = $('#cofferType').val();
        var month = $('#cofferMonth').val();
        var budgetId = $('#BudgetId').val();
        $.post('AddCoffer', {name: name, amount: amount, order: order, necessary: necessary, type: type, month: month, budgetId: budgetId, description: desc});
    });

    $('#addBudget').on('click', function(){
        var name = $('#budgetName').val();
        var description = $('#budgetDescription').val();
        $.post('AddBudget', {name: name, description: description});
    });
