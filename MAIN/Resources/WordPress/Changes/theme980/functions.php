<?php	
if ( function_exists('register_sidebar') )
    register_sidebar(array(
		'name' => __('Left Sidebar', 'theme980'),
        'before_widget' => '	<div id="%1$s" class="widget %2$s"><div class="widget-bgr">',
		'before_title' => '		<div class="title"><div><div><h2>',
        'after_title' => '		</h2></div></div></div>',				
		'after_widget' => '		</div></div>',							
));


// Search 	
	function widget_theme980_search() {
?>

	<div class="widget widget_search" id="search">
		<div class="widget-bgr">
				
			<div class="title">
				<div><div><h2><?php _e('Site Search','theme980'); ?></h2></div></div>
			</div>
		
			<form method="get" id="searchform" action="<?php bloginfo('home'); ?>">	
				<input type="text" class="text" value="<?php the_search_query(); ?>" name="s" id="s" />&nbsp;<input class="but" type="image" src="<?php bloginfo('stylesheet_directory'); ?>/images/search.gif" value="submit" />
			</form>
			
		</div>
	</div>
					
<?php
}
if ( function_exists('register_sidebar_widget') )
	register_sidebar_widget(__('Search'), 'widget_theme980_search');
?>