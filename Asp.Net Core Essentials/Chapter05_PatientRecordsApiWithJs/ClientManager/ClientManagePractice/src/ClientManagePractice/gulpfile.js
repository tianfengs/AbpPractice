/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/
///<binding AfterBuild='stylemaker' ProjectOpened='lesswatcher' /> 
var gulp = require('gulp');
var gulpless = require('gulp-less');

gulp.task('styleMaker', function () {
    // place code for your default task here
    gulp.src('./wwwroot/less/StyleSheet.less')
        .pipe(gulpless({ compress: true }))
        .pipe(gulp.dest("./wwwroot/css"));
});

gulp.task('lesswatcher', function () {
    gulp.watch("./less/*.less", ["stylemaker"]);
}); 