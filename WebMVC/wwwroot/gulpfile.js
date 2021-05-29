//Подключаем модуль Gulp
const { src, dest, series } = require('gulp');       		// сам gulp
const concat 				= require('gulp-concat');   	// объединение файлов в один
const cleanCSS 				= require('gulp-clean-css');	// минификация css
const uglify 				= require('gulp-uglify');   	// минификация js
const scss 					= require('gulp-sass');     	// для конвертирования препроцессорных файлов в обычный css
const autoprefixer 			= require('gulp-autoprefixer');	// вендорные префиксы для css свойств
const imagemin 				= require('gulp-imagemin'); 	// для сжатия картинок
const del 					= require('del');				// для удаления папки build перед вызовом функции build

//Порядок подключения css файлов
const cssFiles = [
	'app/css/reset.css',
	'app/css/style.scss.css'
];

//Порядок подключения scss файлов
const scssFiles = [
	'app/scss/style.scss',
	'app/scss/form.scss',
	'app/scss/student-card-show.scss'
];

//Порядок подключения js файлов
const jsFiles = [
	'app/js/main.js',
	'app/js/sidebar.js',
	'app/js/form.js',
	'app/js/student-card-show.js',
];

function sassToCss() {
	return src(scssFiles)
		.pipe(scss({ outputStyle: 'compressed' }))
		.pipe(concat('style.scss.css'))
		.pipe(dest('app/css'));
}

function styles() {
	return src(cssFiles)
		.pipe(concat('style.min.css'))
		.pipe(cleanCSS({
			level: 2
		}))
		.pipe(autoprefixer({
			overrideBrowserslist: ['last 10 version']
		}))
		.pipe(dest('app/css'));
}

//Таск для скриптов JavaScript 
function scripts() {
	return src(jsFiles)
		.pipe(concat('main.min.js'))
		.pipe(uglify())
		.pipe(dest('app/js'));
}

function images() {
	return src('app/img/**/*')
		.pipe(imagemin([
			imagemin.gifsicle({ interlaced: true }),
			imagemin.mozjpeg({ quality: 75, progressive: true }),
			imagemin.optipng({ optimizationLevel: 5 }),
			imagemin.svgo({
				plugins: [
					{ removeViewBox: true },
					{ cleanupIDs: false }
				]
			})
		]))
		.pipe(dest('build/img'));
}

function build() {
	return src([
		'app/css/style.min.css',
		'app/js/main.min.js',
		'app/index.html'
	], { base: 'app' })
		.pipe(dest('build'));
}

function cleanBuild() {
	return del('build');
}

//Вызов функций
exports.styles = styles;
exports.sassToCss = sassToCss;
exports.scripts = scripts;
exports.images = images;
exports.cleanBuild = cleanBuild;

// если написать gulp build - то функции будут вызываться по очереди (последовательность важна)
exports.build = series(
	cleanBuild,
	images,
	sassToCss,
	styles,
	scripts,
	build);
