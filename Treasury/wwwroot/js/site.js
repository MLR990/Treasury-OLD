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

    $('#addBudget').on('click', function(){
        var name = $('#budgetName').val();
        var amount = $('#budgetAmount').val();
        var order = $('#budgetOrder').val();
        var necessary =  $("#budgetNecessary").prop('checked');
        var type = $('#budgetType').val();
        var month = $('#budgetMonth').val();
        var coffer = $('#CofferId').val();
        $.post('AddBudget', {name: name, amount: amount, order: order, necessary: necessary, type: type, month: month, cofferId: coffer});
    });

    $('#addCoffer').on('click', function(){
        var name = $('#cofferName').val();
        var description = $('#cofferDescription').val();
        $.post('AddCoffer', {name: name, description: description});
    });
