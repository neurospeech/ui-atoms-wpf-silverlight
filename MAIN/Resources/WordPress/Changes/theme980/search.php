<?php get_header(); ?>
<?php get_sidebar(1); ?>

		
		<?php if (have_posts()) : ?>
				
			<div class="title-page02">
				<h2>Search results</h2>
			</div>
	
			<div class="navigation">
				<div class="alignleft"><?php next_posts_link('&lt;&lt; Older Entries') ?></div>
				<div class="alignright"><?php previous_posts_link('Newer Entries &gt;&gt;') ?></div>
				<div class="clear"></div>
			</div>
						
				<?php while (have_posts()) : the_post(); ?>
					<div <?php post_class() ?> id="post-<?php the_ID(); ?>" style=" width:auto;">
							
						<div class="indent">
							<div class="title">
						
								<h3 id="post-<?php the_ID(); ?>"><a href="<?php the_permalink() ?>" rel="bookmark" title="Permanent Link to <?php the_title_attribute(); ?>"><?php the_title(); ?></a></h3>
								
								<div class="date">
								<?php the_time('l, F j, Y') ?> @ <?php the_time('h:m A') ?> posted by <?php the_author_link() ?>
							</div>
								
							</div>
							
							<div class="text-box">
								<?php the_content('Read More'); ?>
							</div>
							
							<div class="postmetadata"><?php the_tags('Tags: ', ', ', '<br />'); ?></div>
				
							<div class="link-edit"><?php edit_post_link('Edit Post', ''); ?></div>
							
							<div class="comments">
								<?php comments_popup_link('0 Comments', '1 Comment', '% Comments', '' , 'off'); ?>
							</div>
					
					
							
							
								
						</div>

					</div>
					
				<?php endwhile; ?>
				</div>
			<div class="navigation nav-top">
				<div class="alignleft"><?php next_posts_link('&lt;&lt; Older Entries') ?></div>
				<div class="alignright"><?php previous_posts_link('Newer Entries &gt;&gt;') ?></div>
			</div>
			
		<?php else : ?>
			<div class="search-page">
				<div class="indent bgnone">
							<div class="title-page01">
							
									<h2>Search result</h2>
									
							</div>
				
							<div class="search_page">
								<div class="text-box">
								
									<p>No posts found. Try a different search?</p>
									<br />
									<form method="get" id="searchform" action="<?php bloginfo('home'); ?>">	
										&nbsp;<input type="text" class="text" value="<?php the_search_query(); ?>" name="s" id="s" />&nbsp;<input class="but" type="image" src="<?php bloginfo('stylesheet_directory'); ?>/images/search.gif" value="submit" />
									</form><br /><br />
								
								</div>
							</div>
				</div>
			</div>	
		<?php endif; ?>



<?php get_footer(); ?>