---
layout: post
---

[https://github.com/mojombo/jekyll/wiki/Template-Data](https://github.com/mojombo/jekyll/wiki/Template-Data)


# site

## site.time 	
The current Time (when you run the jekyll command)

    {{ site.time }}

## site.posts 	
A reverse chronological list of all Posts


## site.related_posts 	
If the page being processed is a Post, this contains a list of up to ten related Posts. By default, these are low quality but fast to compute. For high quality but slow to compute results, run the jekyll command with the --lsi (latent semantic indexing) option

## site.categories.CATEGORY 	
The list of all Posts in category CATEGORY

{% for category in site.categories %}
    {{ category }}
{% endfor %}


## site.tags.TAG
The list of all Posts with tag TAG. 

{% for tag in site.tags %}
    {{ tag }}
{% endfor %}


# page

## page.title 	
The title of the Post.

    {{ page.title }}

## page.url 	
The URL of the Post without the domain. e.g. /2008/12/14/my-post.html

    {{ page.url }}

## page.date 	
The Date assigned to the Post.

    {{ page.date }}

## page.id 	
An identifier unique to the Post (useful in RSS feeds). e.g. /2008/12/14/my-post

    {{ page.id }}

## page.categories 	
The list of categories to which this post belongs. Categories are derived from the directory structure above the _posts directory. For example, a post at /work/code/_posts/2008-12-24-closures.textile would have this field set to ['work', 'code']. These can also be specified in the YAML Front Matter


## page.tags 	
The list of tags to which this post belongs. These can be specified in the YAML Front Matter


## post.content 	
The content of the Post. 

