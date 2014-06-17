// Attach a controller called ItemCtrl to the module.  This controller will handle an 
// indvidual table cell with a grade in it.  We need to do this on a per-cell basis, otherwise
// edit mode would activate for all of the cells at once.  AngularJs lets us spin up multiple 
// controller objects on the same page, they each get their own scope (so one scope per cell)
myApp.controller('ItemCtrl', function ($scope) {
    // we will use this bool to determine whether to show the percent or the point entry
    // input/button.  We want to toggle this on and off by clicking the cell data
    $scope.editMode = false;

    // when they click the cell, we will attach this function to the ng-click event to 
    // toggle editMode to true
    $scope.showForm = function () {
        $scope.editMode = true;
    }

    // When the user is editing, this function will be attached to the ng-click on the button
    // in the real app we won't log, we'll send the actual points to the server then reload 
    // the student grade data for that row.
    $scope.save = function () {
        console.log('You would save ' + $scope.grade.Points + ' for assignmentId ' + $scope.grade.StudentAssignmentId + ' here');
        $scope.editMode = false;
    }
});