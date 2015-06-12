// Gulp
var gulp = require('gulp');

// Sass/CSS stuff
var sass = require('gulp-sass');
var prefix = require('gulp-autoprefixer');
var minifycss = require('gulp-minify-css');

// Images
var imagemin = require('gulp-imagemin');
 
//

// compile all your Sass
gulp.task('sass', function (){
	gulp.src('./source/css/*.scss')
		.pipe(sass({
			includePaths: ['./source/css'],
			outputStyle: 'expanded'
		}))
		.pipe(prefix(
			"last 1 version", "> 1%", "ie 8"
			))
		.pipe(gulp.dest('./source/css'))
		.pipe(minifycss())
		.pipe(gulp.dest('.././Content/css'));
});

// Images

gulp.task('imagemin', function () {
	gulp.src('./source/images/**/*.{png,jpg,jpeg,gif,svg}')
	.pipe(imagemin({
		optimizationLevel: 5,
		progressive: false,
		interlaced: false,
		multipass: true
	}))
	.pipe(gulp.dest('.././Content/images'));
});

//
 
gulp.task('default', ['sass', 'imagemin'], function(){

	// watch me getting Sassy
	gulp.watch("./source/css/**/*.scss", function(event){
		gulp.run('sass');
	});
	// images
	gulp.watch("./source/images/**/*", function(event){
		gulp.run('imagemin');
	});

});
