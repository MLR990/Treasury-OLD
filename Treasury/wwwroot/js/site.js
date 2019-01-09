// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $('#addTransaction').on('click', function(){
        var transactionAmount = $('#transactionAmount').val();
        var desc = $('#transactionDescription').val();
        var vendorId = $('#VendorId').val();
        $.post('AddTransaction', {amount: transactionAmount, description: desc, vendorId: vendorId});
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
        var desc =  $("#budgetDescription").val();
        var type = $('#budgetType').val();
        var month = $('#budgetMonth').val();
        var expenseId = $('#ExpenseId').val();
        $.post('AddBudget', {name: name, amount: amount, order: order, necessary: necessary, type: type, month: month, expenseId: expenseId, description: desc});
    });

    $('#addExpense').on('click', function(){
        var name = $('#expenseName').val();
        var description = $('#expenseDescription').val();
        $.post('AddExpense', {name: name, description: description});
    });

    $('#addIncome').on('click', function(){
        var amount = $('#incomeAmount').val();
        var description = $('#incomeDescription').val();
        var source = $('#incomeSource').val();
        var accountId = $('#AccountId').val();
        $.post('AddIncome', {amount: amount, description: description, source: source, accountId: accountId});
    });

    $('#addAccount').on('click', function(){
        var name = $('#accountName').val();
        var balance = $('#accountBalance').val();
        var type = $('#AccountType').val();
        $.post('AddAccount', {name: name, balance: balance, type: type});
    });
